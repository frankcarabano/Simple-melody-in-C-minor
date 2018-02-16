using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  /*---------------------------------------------------
       F á b r i c a   d e   E s t r a t e g i a s    
      d e   E x t r a c c i ó n   d e   v a l o r e s  
     p a r a   c o n t r o l e s   d e   e d i c i ó n 
    ---------------------------------------------------*/

  public static class FabricaExtractores {
    public static ExtractorValor Crear( Control control ) {
      ExtractorValor extractor = null;
      if ( control is System.Windows.Forms.TextBoxBase ) {
        extractor = new ExtractorTextBoxBase();
      }
      else if ( control is System.Windows.Forms.CheckBox ) {
        extractor = new ExtractorCheckBox();
      }
      else if ( control is System.Windows.Forms.DateTimePicker ) {
        extractor = new ExtractorDateTimePicker();
      }
      else if ( control is System.Windows.Forms.NumericUpDown ) {
        extractor = new ExtractorNumericUpDown();
      }
      else if ( control is System.Windows.Forms.ComboBox ) {
        extractor = new ExtractorComboBox();
      }
      else if ( control is System.Windows.Forms.ListBox ) {
        extractor = new ExtractorListBox();
      }
      else if ( control is System.Windows.Forms.ListView ) {
        extractor = new ExtractorListView();
      }
      else if ( control is System.Windows.Forms.TreeView ) {
        extractor = new ExtractorTreeView();
      }
      return extractor;
    }

  }	//------- Fin Clase FabricaExtractores

}	//------- Fin ES.EsquemaWf.FabricaExtractores.cs