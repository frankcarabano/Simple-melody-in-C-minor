
namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------
    I n d i z a d o r   d e   T o o l S t r i p I t e m s
	   
    Elementos de barras de herramientas y menús
    -------------------------------------------------------*/

  internal class IndizadorToolStripItems {
    private System.Collections.IList items;
    private int inicio;

    internal IndizadorToolStripItems( System.Collections.IList it, int inic ) {
      items = it;
      inicio = inic;
    }

    internal int Indizar() {
      int tag = inicio;
      foreach ( System.Windows.Forms.ToolStripItem I in items ) {
        if ( I != null ) I.Tag = tag++;
      }
      return tag;
    }

  }	//------- Fin Clase IndizadorToolStripItems

}	//------- Fin ES.EsquemaWf.IndizadorToolStripItems.cs