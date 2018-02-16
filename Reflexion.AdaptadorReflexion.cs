using System.Collections;
using System.Reflection;
using Ekia.EsquemaBasico.AdaptacionLibroJCooper;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Reflexion {
  public class AdaptadorReflexion : IReflexion {
    object instancia;
    IListaPropiedades propiedades;
    Stack pilaObjetos;
    Stack pilaPropiedades;

    public AdaptadorReflexion( object objeto ) {
      this.instancia = objeto;
      this.propiedades = new ListaPropiedades();
      obtenerPropiedades( this.instancia );
    }

    public ICollection Propiedades {
      get { return this.propiedades.Lista; }
    }

    public ICollection Nombres {
      get { return this.propiedades.Nombres; }
    }

    public object Origen() {
      return this.instancia;
    }

    public IAdaptadorPtyInf Propiedad( string acceso ) {
      StringTokenizer tokenizer = new StringTokenizer( acceso, "." );
      IAdaptadorPtyInf propiedad = this.propiedades[tokenizer.ProximoToken()];
      while ( tokenizer.HayMasTokens() ) {
        propiedad = propiedad.Propiedades[tokenizer.ProximoToken()];
      }
      return propiedad;
    }

    public object InvocarMetodo( string acceso, object[] parametros ) {
      string nombreMetodo = accesarMetodo( acceso );
      object resultadoMetodo = null;
      MethodInfo infoMetodo = this.instancia.GetType().GetMethod( nombreMetodo );
      if ( infoMetodo != null ) resultadoMetodo = infoMetodo.Invoke( this.instancia, parametros );
      if ( nombreMetodo != acceso ) recuperarInstanciaOrigen();
      return resultadoMetodo;
    }

    void obtenerPropiedades( object objeto ) {
      foreach ( PropertyInfo pi in objeto.GetType().GetProperties() ) {
        this.propiedades.Agregar( new AdaptadorPropiedad( pi, objeto ) );
        if ( esModelo( pi ) ) {
          cambiarInstancia( pi );
          obtenerPropiedades( this.instancia );
          recuperarInstanciaOrigen();
        }
      }
    }

    void cambiarInstancia( PropertyInfo ptyInfo ) {
      if ( ( this.pilaObjetos == null ) && ( this.pilaPropiedades == null ) ) {
        this.pilaObjetos = new Stack();
        this.pilaPropiedades = new Stack();
      }
      this.pilaObjetos.Push( this.instancia );
      this.pilaPropiedades.Push( this.propiedades );
      this.instancia = this.instancia.GetType().GetProperty( ptyInfo.Name ).GetValue( this.instancia, null );
      this.propiedades = this.propiedades[ptyInfo.Name].Propiedades;
    }

    void recuperarInstanciaOrigen() {
      if ( ( this.pilaObjetos != null ) && ( this.pilaPropiedades != null ) ) {
        while ( ( this.pilaObjetos.Count > 0 ) && ( this.pilaPropiedades.Count > 0 ) ) {
          this.instancia = this.pilaObjetos.Pop();
          this.propiedades = (IListaPropiedades)this.pilaPropiedades.Pop();
        }
        this.pilaObjetos = null;
        this.pilaPropiedades = null;
      }
    }

    bool esModelo( PropertyInfo pi ) {
      return pi.GetCustomAttributes( true ).Length > 0 && ( pi.GetCustomAttributes( true )[0] as ModelPropertyAttribute ).EsModelo;
    }

    string accesarMetodo( string acceso ) {
      StringTokenizer tokenizer = new StringTokenizer( acceso, "." );
      while ( tokenizer.CuentaTokens > 1 ) {
        IAdaptadorPtyInf propiedad = this.propiedades[tokenizer.ProximoToken()];
        cambiarInstancia( propiedad.Origen() );
      }
      return tokenizer.ProximoToken();
    }

  }	//------- Fin Clase AdaptadorReflexion

}	//------- Fin AdaptadorReflexion.cs