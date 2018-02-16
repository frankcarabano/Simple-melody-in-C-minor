using System;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Mvc {
  public class ValorInvalido : ApplicationException {
    private IValorEstado valor;
    private Incumplimientos incumplimientos;

    public ValorInvalido( string message, IValorEstado valor, Incumplimientos incumplimientos ) : base( message ) {
      this.valor = valor;
      this.incumplimientos = incumplimientos;
    }

    public IValorEstado Valor {
      get { return this.valor; }
    }

    public IIteradorLista<string> Incumplimientos {
      get { return this.incumplimientos.Descripciones; }
    }

    public string TextoIncumplimientos {
      get { return this.incumplimientos.ToString(); }
    }

  }	//------- Fin clase ValorInvalido

}	//------- Fin ES.ReglasValidacion.ValorInvalido.cs