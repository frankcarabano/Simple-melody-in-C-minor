using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n   
            p a r a   c o n t r o l e s   C h e c k B o x              
    -------------------------------------------------------------*/

  public class ExtractorCheckBox : ExtractorValor {
    internal ExtractorCheckBox() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.CheckBox );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      valor.Contenido = ( control as System.Windows.Forms.CheckBox ).Checked;
    }

  }	//------- Fin Clase ExtractorCheckBox

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorCheckBox.cs