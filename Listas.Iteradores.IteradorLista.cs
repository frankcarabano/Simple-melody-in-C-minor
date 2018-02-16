using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
  /*-----------------------------------------------------
     C l a s e   I t e r a d o r   p a r a   L i s t a s 
    -----------------------------------------------------*/

  public delegate bool PasaFiltro( object elemento );

  public class IteradorLista<TElemento> : IIteradorLista<TElemento> {
    IList<TElemento> lista;
    int posicion;
    PasaFiltro pasaFiltro;

    public IteradorLista( IList<TElemento> lista ) {
      this.lista = lista;
      this.posicion = -1;
      this.pasaFiltro = null;
    }

    public IteradorLista( IList<TElemento> lista, PasaFiltro operacionFiltro ) {
      this.lista = lista;
      this.posicion = -1;
      this.pasaFiltro = operacionFiltro;
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public TElemento Actual {
      get {
        object resultado = null;
        if ( this.lista.Count > 0 ) {
          resultado = this.lista[posicion];
        }
        return (TElemento)resultado;
      }
    }

    public void Iniciar() {
      this.posicion = -1;
    }

    public bool Iterar() {
      bool iterable = !listaVacia();                  // iteramos sólo si hay elementos en la lista
      if ( iterable ) {
        this.posicion++;                              // nos movemos una posición hacia adelante
        iterable = !eol();                            // verificamos que la posición esté dentro de los límites de la lista
        if ( iterable && this.pasaFiltro != null ) {  // si estamos dentro de los límites y hay definida operación de filtrado
          iterable = actualPasaFiltro();              // decimos que podemos iterar si el elemento pasa la prueba de filtrado
          while ( !iterable ) {                       // de no pasar la prueba, mientras no haya elementos que la pasen
            this.posicion++;                          // si el elemento siguiente no es el último
            if ( !eol() ) {
              iterable = actualPasaFiltro();          // verificamos que los elementos subsiguientes pasen la prueba
              if ( iterable ) {                       // si el elemento pasa la prueba salimos del ciclo
                break;
              }
            }
            else {                                    // si es el último entonces salir
              break;
            }
          }
        }
      }
      return iterable;
    }

    bool listaVacia() {
      return this.lista.Count == 0;
    }

    bool eol() {
      return this.posicion >= this.lista.Count;
    }

    bool actualPasaFiltro() {
      return this.pasaFiltro( this.lista[this.posicion] );
    }

  }	//------- Fin clase IteradorLista

}	//------- Fin ES.Listas.Iteradores.IteradorLista.cs