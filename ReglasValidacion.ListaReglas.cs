using System.Collections;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Mvc {
  public delegate bool MetodoValidacion( IValorEstado valor, Incumplimientos incumplimientos );

  public class ListaReglas {
    private IList<MetodoValidacion> reglas;

    internal ListaReglas() {
      this.reglas = new List<MetodoValidacion>();
    }

    public ICollection Reglas {
      get { return ( this.reglas as List<MetodoValidacion> ).AsReadOnly(); }
    }

    public void Agregar( MetodoValidacion regla ) {
      if ( !( this.reglas.Contains( regla ) ) ) {
        this.reglas.Add( regla );
      }
    }

    public void Eliminar( MetodoValidacion regla ) {
      if ( this.reglas.Contains( regla ) ) {
        this.reglas.Remove( regla );
      }
    }

  }	//------- Fin Clase ListaReglas

}	//------- Fin ES.ReglasValidacion.ListaReglas.cs