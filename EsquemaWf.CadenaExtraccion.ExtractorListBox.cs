using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n  
            p a r a   c o n t r o l e s   L i s t B o x                
    -------------------------------------------------------------*/

  public class ExtractorListBox : ExtractorValor {
    internal ExtractorListBox() { }
    public override bool PuedeExtraer( Control control ) {
      return ( ( control is System.Windows.Forms.ListBox ) &&
              ( ( control as System.Windows.Forms.ListBox ).SelectionMode == SelectionMode.One ) );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      if ( this.infoPropiedad.TipoBase == "Enum" ) {
        valor.Contenido = ( control as System.Windows.Forms.ListBox ).SelectedIndex;
      }
      else {
        valor.Contenido = ( control as System.Windows.Forms.ListBox ).SelectedItem;
      }
    }

  }	//------- Fin Clase ExtractorListBox

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorListBox.cs