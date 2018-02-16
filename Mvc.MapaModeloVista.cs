using System.Collections.Generic;

namespace Ekia.EsquemaBasico.Mvc {
  public class MapaMV {
    IDictionary<string, string> entradas;

    internal MapaMV() {
      this.entradas = new Dictionary<string, string>();
    }

    public string this[string widget] {
      get {
        string propiedad = string.Empty;
        if ( this.entradas.ContainsKey( widget ) ) {
          propiedad = this.entradas[widget];
        }
        return propiedad;
      }
    }

    public int Conteo {
      get { return this.entradas.Keys.Count; }
    }

    public ICollection<string> Widgets {
      get {
        IList<string> widgets = new List<string>();
        foreach ( string s in this.entradas.Keys ) {
          widgets.Add( s );
        }
        return ( widgets as List<string> ).AsReadOnly();
      }
    }

    public void Mapear( string widget, string propiedad ) {
      this.entradas.Add( widget, propiedad );
    }

    public void Editar( string widget, string propiedad ) {
      this.entradas[widget] = propiedad;
    }

    public void Eliminar( string widget ) {
      this.entradas.Remove( widget );
    }

    public void Limpiar() {
      this.entradas.Clear();
    }

  }	//------- Fin Clase MapaMV

}	//------- Fin ES.MapaModeloVista.cs