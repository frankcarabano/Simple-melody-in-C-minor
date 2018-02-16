using System;
using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  public class SoloNumericoDecorator : TextBoxDecorator {
    public SoloNumericoDecorator( System.Windows.Forms.TextBox origen ) : base( origen ) { }

    public override void InicioEdicion( object sender, EventArgs e ) { }

    public override void ValidarTecla( object sender, KeyPressEventArgs kpe ) {
      if ( !( char.IsControl( kpe.KeyChar ) ) && !( char.IsDigit( kpe.KeyChar ) ) ) {
        kpe.Handled = true;
      }
    }

    public override void Formatear() { }

  }	//------- Fin Clase SoloNumericoDecorator

}	//------- Fin ES.EsquemaWf.Decoradores.SoloNumericoDecorator.cs