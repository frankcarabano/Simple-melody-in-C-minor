using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.EsquemaBasico.Mvc {
  public class Incumplimientos {
    private IList<string> lista;

    internal Incumplimientos() {
      this.lista = new List<string>();
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public IIteradorLista<string> Descripciones {
      get { return new IteradorLista<string>( this.lista ); }
    }

    public void Agregar( string incumplimiento ) {
      this.lista.Add( incumplimiento );
    }

    public void Limpiar() {
      this.lista.Clear();
    }

    public override string ToString() {
      string texto = string.Empty;
      foreach ( string S in this.lista ) {
        texto += S + '\n';
      }
      return texto;
    }

  }	//------- Fin Clase Incumplimientos

}	//------- Fin ES.ReglasValidacion.Incumplimientos.cs