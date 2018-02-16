using System;
using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  public interface ITextBoxDecorator {
    void InicioEdicion( object sender, EventArgs e );
    void ValidarTecla( object sender, KeyPressEventArgs kpe );
    void Formatear();
  }

}	//------- Fin ES.EsquemaWf.Decoradores.ITextBoxDecorator.cs