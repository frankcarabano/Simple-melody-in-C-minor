using System;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n   
       p a r a   c o n t r o l e s   N u m e r i c U p D o w n    
    -------------------------------------------------------------*/

  public class ExtractorNumericUpDown : ExtractorValor {
    internal ExtractorNumericUpDown() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.NumericUpDown );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      switch ( this.tipoPropiedad ) {
        case "Int32":
          valor.Contenido = Convert.ToInt32( ( control as System.Windows.Forms.NumericUpDown ).Value );
          break;
        case "Int64":
          valor.Contenido = Convert.ToInt64( ( control as System.Windows.Forms.NumericUpDown ).Value );
          break;
        default:
          valor.Contenido = ( control as System.Windows.Forms.NumericUpDown ).Value;
          break;
      }
    }

  }	//------- Fin Clase ExtractorNumericUpDown

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorNumericUpDown.cs