using System;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Listas {
  /*---------------------------------------------------
     E x c e p c i o n   C l a v e   d u p l i c a d a    
    ---------------------------------------------------*/

  public class ClaveDuplicada : ApplicationException {
    public ClaveDuplicada( string message ) : base( message ) { }
  }

  /*----------------------------------------------
    C l a s e    b a s e   p a r a   L i s t a s 
   -----------------------------------------------*/

  public abstract class FicheroMaestro<TInstancia> : IFicheroMaestro<TInstancia> {
    protected IList<TInstancia> lista;
    protected IList<string> indiceClave;
    protected IList<string> indiceOIds;
    protected string nombreClave;
    IIteradorLista<TInstancia> iterador;

    public FicheroMaestro( string nombreClave ) {
      inicializar();
      this.indiceClave = new List<string>();
      this.indiceOIds = new List<string>();
      this.nombreClave = nombreClave;
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public bool EstaVacante {
      get { return ( this.lista.Count == 0 ); }
    }

    public TInstancia this[string clave] {
      get { return instanciaPorClave( clave ); }
    }

    public IList<TInstancia> Lista {
      get { return ( this.lista as List<TInstancia> ).AsReadOnly(); }
    }

    public IIteradorLista<TInstancia> Iterador {
      get {
        if ( this.iterador == null || this.iterador.Conteo != this.lista.Count ) {
          this.iterador = new IteradorLista<TInstancia>( this.lista as List<TInstancia> );
        }
        return this.iterador;
      }
    }

    public string NombreClave {
      get { return this.nombreClave; }
    }

    public abstract TInstancia CrearInstancia();

    public TInstancia InstanciaPorOId( string oid ) {
      return instanciaPorOId( oid );
    }

    public TInstancia InstanciaPorClave( string clave ) {
      return instanciaPorClave( clave );
    }

    public IFicheroMaestro<TInstancia> Recuperar() {
      recuperar();
      return this;
    }

    public IEnumerable<TInstancia> Instancias() {
      if ( this.lista.Count == 0 ) {
        Recuperar();
      }
      foreach ( TInstancia i in this.lista ) {
        yield return i;
      }
    }

    public abstract void GuardarInstancia( TInstancia instancia );

    public void ActivarInstancia( TInstancia elemento ) {
      if ( this.lista.Contains( elemento ) && elemento is IActivable ) {
        ( elemento as IActivable ).Activar();
      }
    }

    public void DesactivarInstancia( TInstancia elemento ) {
      if ( this.lista.Contains( elemento ) && elemento is IActivable ) {
        ( elemento as IActivable ).Desactivar();
      }
    }

    public void EliminarInstancia( TInstancia instancia ) {
      bool eliminado = false;
      if ( this.lista.Contains( instancia ) ) {
        try {
          eliminarInstancia( instancia );
          eliminado = this.lista.Remove( instancia );
          if ( eliminado ) {
            actualizarIndices();
          }
        }
        catch ( ApplicationException e ) {
          throw e;
        }
      }
    }

    public void IncluirInstancia( TInstancia elemento ) {
      string clave = claveInstancia( elemento );
      if ( !( this.indiceClave.Contains( clave ) ) ) {
        this.lista.Add( elemento );
        actualizarIndices();
      }
      else {
        string mensaje = mensajeClaveDuplicada();
        throw new ClaveDuplicada( mensaje + clave );
      }
    }

    public bool ContieneClave( string clave ) {
      return this.indiceClave.Contains( clave );
    }

    public void Indizar() {
      actualizarIndices();
    }

    public void Limpiar() {
      this.lista.Clear();
      this.indiceClave.Clear();
      this.indiceOIds.Clear();
    }

    protected abstract void recuperar();
    protected abstract void inicializar();
    protected abstract string mensajeClaveDuplicada();
    protected abstract void eliminarInstancia( TInstancia instancia );

    protected TInstancia instanciaPorClave( string clave ) {
      object resultado = null;
      if ( this.lista.Count > 0 ) {
        if ( this.indiceClave.Contains( clave ) ) {
          int indice = this.indiceClave.IndexOf( clave );
          resultado = this.lista[indice];
        }
      }
      return (TInstancia)resultado;
    }

    protected TInstancia instanciaPorOId( string oid ) {
      object resultado = null;
      if ( this.lista.Count > 0 ) {
        if ( this.indiceOIds.Contains( oid ) ) {
          int indice = this.indiceOIds.IndexOf( oid );
          resultado = this.lista[indice];
        }
      }
      return (TInstancia)resultado;
    }

    protected void actualizarIndices() {
      this.indiceClave.Clear();
      this.indiceOIds.Clear();
      foreach ( TInstancia t in this.lista ) {
        this.indiceClave.Add( claveInstancia( t ) );
        this.indiceOIds.Add( ( t as IOid ).OId );
      }
    }

    string claveInstancia( TInstancia instancia ) {
      return Reflector.ObtenerValorPropiedad( instancia, this.nombreClave ).ToString();
    }

  }	//------- Fin clase FicheroMaestro

}	//------- Fin ES.Listas.FicheroMaestro.cs