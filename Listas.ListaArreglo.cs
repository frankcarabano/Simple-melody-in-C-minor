using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
  /*---------------------------------------------------------------
    I m p l e m e n t a c i ó n   b a s e   p a r a   L i s t a s 
              g e n é r i c a s   e s t i l o   A r r a y                 
   ----------------------------------------------------------------*/

  public abstract class ListaArreglo<TInstancia> : IListaArreglo<TInstancia> {
    protected IList<TInstancia> lista;

    public ListaArreglo() {
      this.lista = new List<TInstancia>();
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public bool EstaVacante {
      get { return ( this.lista.Count == 0 ); }
    }

    public TInstancia this[int indice] {
      get {
        object resultado = null;
        if ( ( indice >= 0 ) && ( indice <= ( this.lista.Count - 1 ) ) ) {
          resultado = lista[indice];
        }
        return (TInstancia)resultado;
      }
    }

    public abstract IIteradorLista<TInstancia> Iterador {
      get;
    }

    public virtual void IncluirInstancia( TInstancia instancia ) {
      this.lista.Add( instancia );
    }

    public bool ContieneInstancia( TInstancia instancia ) {
      return this.lista.Contains( instancia );
    }

    public void Limpiar() {
      this.lista.Clear();
    }

  }	//------- Fin clase ListaArreglo<TElemento>

}	//------- Fin ES.Listas.ListaArreglo.cs