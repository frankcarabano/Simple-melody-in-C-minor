using System.Collections.Generic;

namespace Ekia.EsquemaBasico.Mvc {
  public class IncumplimientosReglas {
    IDictionary<string, Incumplimientos> entradas;

    internal IncumplimientosReglas() {
      this.entradas = new Dictionary<string, Incumplimientos>();
    }

    public int Conteo {
      get { return this.entradas.Keys.Count; }
    }

    public void Agregar( string propiedad, Incumplimientos incumplimientos ) {
      if ( this.entradas.ContainsKey( propiedad ) ) {
        Eliminar( propiedad );
      }
      this.entradas.Add( propiedad, incumplimientos );
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
  }

}	//------- Fin ES.ReglasValidacion.IncumplimientosReglas.cs