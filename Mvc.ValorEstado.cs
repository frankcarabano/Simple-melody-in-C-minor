using System;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Mvc {
  /*-------------------------------------------------------------------------------------
     I M P L E M E N T A C I O N   P A R A   V A L O R E S   D E   P R O P I E D A D E S 
    -------------------------------------------------------------------------------------*/

  public class ValorEstado : IValorEstado {
    private object contenido;

    public ValorEstado() {
      this.contenido = null;
    }

    public ValorEstado( object cont ) {
      this.contenido = cont;
    }

    public object Contenido {
      get { return this.contenido; }
      set { this.contenido = value; }
    }

    public string ComoCadena() {
      string valor = string.Empty;
      if ( ( this.contenido != null ) && ( this.contenido is String ) ) {
        valor = this.contenido.ToString();
      }
      return valor;
    }

    public int ComoEntero() {
      int valor = 0;
      if ( ( this.contenido != null ) && ( this.contenido is Int32 ) ) {
        valor = Convert.ToInt32( this.contenido );
      }
      return valor;
    }

    public double ComoDoble() {
      double valor = 0;
      if ( ( this.contenido != null ) && ( this.contenido is Double ) ) {
        valor = Convert.ToDouble( this.contenido );
      }
      return valor;
    }

    public decimal ComoDecimal() {
      decimal valor = 0;
      if ( ( this.contenido != null ) && ( this.contenido is Decimal ) ) {
        valor = Convert.ToDecimal( this.contenido );
      }
      return valor;
    }

    public bool ComoBoolean() {
      bool valor = true;
      if ( ( this.contenido != null ) && ( this.contenido is Boolean ) ) {
        valor = Convert.ToBoolean( this.contenido );
      }
      return valor;
    }

    public DateTime ComoTiempo() {
      DateTime valor = DateTime.Now;
      if ( ( this.contenido != null ) && ( this.contenido is DateTime ) ) {
        valor = (DateTime)this.contenido;
      }
      return valor;
    }

    public IList<object> ComoLista() {
      IList<object> valor = null;
      if ( ( this.contenido != null ) && ( this.contenido is IList<object> ) ) {
        valor = (IList<object>)this.contenido;
      }
      return valor;
    }

  }	//------- Fin clase ValorEstado

}	//------- Fin ES.Mvc.ValorEstado.cs