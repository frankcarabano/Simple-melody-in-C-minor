using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
  /*-------------------------------------------------------
     C l a s e   N a v e g a d o r   p a r a   L i s t a s 
    --------------------------------------------------------*/

  public class NavegadorFicheroMaestro<TInstancia> : INavegadorFicheroMaestro<TInstancia> {
    IList<TInstancia> lista;
    int posicion;

    public NavegadorFicheroMaestro( IList<TInstancia> lista ) {
      this.lista = lista;
      this.posicion = 0;
    }

    public int Posicion {
      get { return ( this.posicion + 1 ); }
    }

    public TInstancia Instancia( int indice ) {
      if ( indice <= 0 ) {
        posicion = 0;
      }
      else if ( indice < ( this.lista.Count - 1 ) ) {
        posicion = indice;
      }
      else if ( indice >= ( this.lista.Count - 1 ) ) {
        posicion = this.lista.Count - 1;
      }
      return this.lista[posicion];
    }

    public TInstancia Actual() {
      TInstancia resultado = default( TInstancia );
      if ( this.lista.Count > 0 ) {
        resultado = Instancia( posicion );
      }
      return resultado;
    }

    public TInstancia Primera() {
      TInstancia resultado = default( TInstancia );
      if ( this.lista.Count > 0 ) {
        posicion = 0;
        resultado = Instancia( posicion );
      }
      return resultado;
    }

    public TInstancia Anterior() {
      TInstancia resultado = default( TInstancia );
      if ( this.lista.Count > 0 ) {
        posicion--;
        if ( posicion < 0 ) posicion = 0;
        resultado = Instancia( posicion );
      }
      return resultado;
    }

    public TInstancia Siguiente() {
      TInstancia resultado = default( TInstancia );
      if ( this.lista.Count > 0 ) {
        posicion++;
        if ( posicion >= this.lista.Count ) posicion = this.lista.Count - 1;
        resultado = Instancia( posicion );
      }
      return resultado;
    }

    public TInstancia Ultima() {
      TInstancia resultado = default( TInstancia );
      if ( this.lista.Count > 0 ) {
        posicion = this.lista.Count - 1;
        resultado = Instancia( posicion );
      }
      return resultado;
    }

  }	//------- Fin clase NavegadorFicheroMaestro

}	//------- Fin ES.Listas.Iteradores.NavegadorFicheroMaestro.cs