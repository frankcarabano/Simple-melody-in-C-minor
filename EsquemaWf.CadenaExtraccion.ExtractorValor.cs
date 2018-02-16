using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------
     C l a s e   b a s e   p a r a   E s t r a t e g i a s   d e 
            e x t r a c c i ó n   d e   v a l o r e s   d e       
                c o n t r o l e s   d e   e d i c i ó n           
    -------------------------------------------------------------*/

  public abstract class ExtractorValor {
    protected ExtractorValor sucesor;
    protected IAdaptadorPtyInf infoPropiedad;
    protected string tipoPropiedad;

    internal ExtractorValor() {
      this.sucesor = null;
      this.infoPropiedad = null;
      this.tipoPropiedad = string.Empty;
    }

    public ExtractorValor Sucesor {
      get { return this.sucesor; }
      set { this.sucesor = value; }
    }

    public void Extraer( System.Windows.Forms.Control control, IAdaptadorPtyInf infoProp, IValorEstado valor ) {
      if ( PuedeExtraer( control ) ) {
        this.infoPropiedad = infoProp;
        this.tipoPropiedad = this.infoPropiedad.Tipo;
        extraerValor( control, valor );
      }
      else {
        if ( this.sucesor != null ) {
          this.sucesor.Extraer( control, infoProp, valor );
        }
      }
    }

    public abstract bool PuedeExtraer( System.Windows.Forms.Control control );
    protected abstract void extraerValor( System.Windows.Forms.Control control, IValorEstado valor );

  }	//------- Fin Clase ExtractorValor

}	//------- Fin ES.EsquemaWf.CadenaExtraccion.ExtractorValor.cs