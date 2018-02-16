using System;
using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  public abstract class TextBoxDecorator : ITextBoxDecorator {
    protected System.Windows.Forms.TextBox cajaTexto;

    public TextBoxDecorator( System.Windows.Forms.TextBox origen ) {
      this.cajaTexto = origen;

      this.cajaTexto.Enter += new EventHandler( this.InicioEdicion );
      this.cajaTexto.KeyPress += new KeyPressEventHandler( this.ValidarTecla );
    }
    public abstract void InicioEdicion( object sender, EventArgs e );
    public abstract void ValidarTecla( object sender, KeyPressEventArgs kpe );
    public abstract void Formatear();
  }

}	//------- Fin ES.EsquemaWf.Decoradores.TextBoxDecorator.cs