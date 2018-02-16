using System;
using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  public class SoloAlfabeticoDecorator : TextBoxDecorator {
    public SoloAlfabeticoDecorator( System.Windows.Forms.TextBox origen ) : base( origen ) { }

    public override void InicioEdicion( object sender, EventArgs e ) { }

    public override void ValidarTecla( object sender, KeyPressEventArgs kpe ) {
      if ( !( char.IsControl( kpe.KeyChar ) ) && !( char.IsLetter( kpe.KeyChar ) || char.IsWhiteSpace( kpe.KeyChar ) ) ) {
        kpe.Handled = true;
      }
    }

    public override void Formatear() { }

  }	//------- Fin Clase SoloAlfabeticoDecorator

}	//------- Fin ES.EsquemaWf.Decoradores.SoloAlfabeticoDecorator.cs