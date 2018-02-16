using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n  
            p a r a   c o n t r o l e s   T r e e V i e w       
    -------------------------------------------------------------*/

  public class ExtractorTreeView : ExtractorValor {
    internal ExtractorTreeView() { }
    public override bool PuedeExtraer( Control control ) {
      return ( control is System.Windows.Forms.TreeView );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      valor.Contenido = ( ( control as System.Windows.Forms.TreeView ).SelectedNode.Tag != null ?
                         ( control as System.Windows.Forms.TreeView ).SelectedNode.Tag : null );
    }

  }	//------- Fin Clase ExtractorTreeView

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorTreeview.cs