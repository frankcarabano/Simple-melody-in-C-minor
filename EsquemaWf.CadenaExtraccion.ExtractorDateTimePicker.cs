using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n   
      p a r a   c o n t r o l e s   D a t e T i m e P i c k e r  
    -------------------------------------------------------------*/

  public class ExtractorDateTimePicker : ExtractorValor {
    internal ExtractorDateTimePicker() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.DateTimePicker );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      valor.Contenido = ( control as System.Windows.Forms.DateTimePicker ).Value;
    }

  }	//------- Fin Clase ExtractorDateTimePicker

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorDateTimePicker.cs