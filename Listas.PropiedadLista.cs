using System;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Listas {
  /* -------------------------------------------------------------------
      C L A S E   B A S E   P A R A   P R O P I E D A D E S - L I S T A 
     ---------------------------------------------------------------------*/

  public abstract class PropiedadLista<TInstancia> : IPropiedadLista<TInstancia> where TInstancia : IOid {
    protected IDictionary<string, TInstancia> lista;
    protected string nombreClave;
    IIteradorLista<TInstancia> iterador;

    public PropiedadLista( string nombreClave ) {
      this.lista = new Dictionary<string, TInstancia>();
      this.nombreClave = nombreClave;
      this.iterador = null;
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public bool EstaVacante {
      get { return this.lista.Count == 0; }
    }

    public TInstancia this[string clave] {
      get {
        TInstancia instancia = default( TInstancia );
        if ( this.lista.ContainsKey( clave ) ) {
          instancia = this.lista[clave];
        }
        return instancia;
      }
    }

    public IIteradorLista<TInstancia> Iterador {
      get {
        if ( this.iterador == null || this.iterador.Conteo != this.lista.Count ) {
          IList<TInstancia> instancias = new List<TInstancia>();
          foreach ( TInstancia instancia in this.lista.Values ) {
            instancias.Add( instancia );
          }
          this.iterador = new IteradorLista<TInstancia>( instancias );
        }
        return this.iterador;
      }
    }

    public string NombreClave {
      get { return this.nombreClave; }
    }

    public void Limpiar() {
      this.lista.Clear();
    }

    public void IncluirInstancia( object instancia ) {
      if ( instancia is TInstancia ) {
        IncluirInstancia( (TInstancia)instancia );
      }
    }

    public void IncluirInstancia( TInstancia instancia ) {
      try {
        this.lista.Add( claveInstancia( instancia ), instancia );
      }
      catch ( ArgumentException e ) {
        manejarDuplicado( instancia );
      }
    }

    public abstract bool EliminarInstancia( string clave );

    public bool ContieneClave( string clave ) {
      return this.lista.ContainsKey( clave );
    }

    public TInstancia Instancia( string oid ) {
      TInstancia instancia = default( TInstancia );
      foreach ( TInstancia i in this.lista.Values ) {
        if ( i.OId == oid ) {
          instancia = i;
          break;
        }
      }
      return instancia;
    }

    protected abstract void manejarDuplicado( TInstancia instancia );

    string claveInstancia( TInstancia instancia ) {
      return Reflector.ObtenerValorPropiedad( instancia, this.nombreClave ).ToString();
    }

  }	//------- Fin clase PropiedadLista

}	//------- Fin ES.Listas.PropiedadLista.cs