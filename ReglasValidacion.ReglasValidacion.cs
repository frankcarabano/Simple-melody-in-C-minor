using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Mvc {
  public class ReglasValidacion {
    private IDictionary<string, ListaReglas> entradas;

    internal ReglasValidacion() {
      this.entradas = new Dictionary<string, ListaReglas>();
    }

    public int Conteo {
      get { return this.entradas.Keys.Count; }
    }

    public void Agregar( string propiedad, MetodoValidacion regla ) {
      if ( !this.entradas.ContainsKey( propiedad ) ) {
        this.entradas.Add( propiedad, new ListaReglas() );
      }
      this.entradas[propiedad].Agregar( regla );
    }

    public void Eliminar( string propiedad ) {
      if ( this.entradas.ContainsKey( propiedad ) ) {
        this.entradas.Remove( propiedad );
      }
    }

    public void Limpiar() {
      this.entradas.Clear();
    }

    public bool Contiene( string propiedad ) {
      return ( this.entradas.ContainsKey( propiedad ) );
    }

    public Incumplimientos Validar( string propiedad, IValorEstado valor ) {
      Incumplimientos incumplimientos = null;
      if ( this.entradas.ContainsKey( propiedad ) ) {
        incumplimientos = new Incumplimientos();
        bool valido = true;
        foreach ( MetodoValidacion Regla in this.entradas[propiedad].Reglas ) {
          valido &= Regla( valor, incumplimientos );
        }
      }
      return incumplimientos;
    }

  }	//------- Fin Clase ReglasValidacion

}	//------- Fin ES.ReglasValidacion.ReglasValidacion.cs