using System.Collections.Generic;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   E s t r a t e g i a   d e   e x t r a c c i ó n  
            p a r a   c o n t r o l e s   L i s t V i e w       
    -------------------------------------------------------------*/

  public class ExtractorListView : ExtractorValor {
    internal ExtractorListView() { }
    public override bool PuedeExtraer( Control control ) {
      return ( ( control is System.Windows.Forms.ListView ) &&
              ( ( control as System.Windows.Forms.ListView ).MultiSelect == false ) );
    }
    protected override void extraerValor( System.Windows.Forms.Control control, IValorEstado valor ) {
      if ( this.infoPropiedad.Implementa( "IPropiedadLista" ) ) {
        IList<object> lista = new List<object>();
        foreach ( ListViewItem lvi in ( control as System.Windows.Forms.ListView ).Items ) {
          if ( lvi.Tag != null ) {
            lista.Add( lvi.Tag );
          }
        }
        valor.Contenido = lista;
      }
      else {
        valor.Contenido = ( ( control as System.Windows.Forms.ListView ).SelectedItems[0].Tag != null ?
                               ( control as System.Windows.Forms.ListView ).SelectedItems[0].Tag : null );
      }
    }

  }	//------- Fin Clase ExtractorListView

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorListView.cs