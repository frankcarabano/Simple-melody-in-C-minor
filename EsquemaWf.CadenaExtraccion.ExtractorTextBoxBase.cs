using System;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n   
         p a r a   c o n t r o l e s   T e x t B o x B a s e           
    -------------------------------------------------------------*/

  public class ExtractorTextBoxBase : ExtractorValor {
    internal ExtractorTextBoxBase() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.TextBoxBase );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      string texto = ( control as System.Windows.Forms.TextBoxBase ).Text;
      valor.Contenido = texto;
      switch ( this.tipoPropiedad ) {
        case "Int32":
          if ( texto.Length > 0 ) {
            valor.Contenido = Convert.ToInt32( texto );
          }
          else {
            valor.Contenido = 0;
          }
          break;
        case "Int64":
          if ( texto.Length > 0 ) {
            valor.Contenido = Convert.ToInt64( texto );
          }
          else {
            valor.Contenido = 0;
          }
          break;
        case "Double":
          if ( texto.Length > 0 ) {
            valor.Contenido = Convert.ToDouble( texto );
          }
          else {
            valor.Contenido = 0;
          }
          break;
      }
    }

  }	//------- Fin Clase ExtractorTextBoxBase

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorTextBoxBase.cs