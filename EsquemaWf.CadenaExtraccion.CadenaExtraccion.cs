using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*------------------------------------------------------------------
        C l a s e   C a d e n a   d e   e x t r a c c i ó n   d e     
       v a l o r e s   d e   c o n t r o l e s   d e   e d i c i ó n   
      ( P a t r ó n   C h a i n   o f   R e s p o n s i b i l i t y )  
    ------------------------------------------------------------------*/

  public class CadenaExtraccion {
    IList<ExtractorValor> extractores;

    internal CadenaExtraccion() {
      this.extractores = new List<ExtractorValor>();
    }

    public void Agregar( ExtractorValor extractor ) {
      if ( !contieneExtractor( extractor ) ) {
        this.extractores.Add( extractor );
        int cuenta = this.extractores.Count;
        if ( cuenta > 1 ) {
          this.extractores[( cuenta - 2 )].Sucesor = this.extractores[( cuenta - 1 )];
        }
      }
    }

    public void ExtraerValorControl( System.Windows.Forms.Control control, IAdaptadorPtyInf infoProp, IValorEstado valor ) {
      this.extractores[0].Extraer( control, infoProp, valor );
    }

    bool contieneExtractor( ExtractorValor extractor ) {
      bool contiene = false;
      foreach ( ExtractorValor E in this.extractores ) {
        if ( E.GetType() == extractor.GetType() ) {
          contiene = true;
          break;
        }
      }
      return contiene;
    }

  }	//------- Fin Clase CadenaExtraccion

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.CadenaExtraccion.cs