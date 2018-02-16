using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n  
            p a r a   c o n t r o l e s   C o m b o B o x              
    -------------------------------------------------------------*/

  public class ExtractorComboBox : ExtractorValor {
    internal ExtractorComboBox() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.ComboBox );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      if ( this.infoPropiedad.TipoBase == "Enum" ) {
        valor.Contenido = ( control as System.Windows.Forms.ComboBox ).SelectedIndex;
      }
      else {
        valor.Contenido = ( control as System.Windows.Forms.ComboBox ).SelectedItem;
      }
    }

  }	//------- Fin Clase ExtractorComboBox

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorComboBox.cs