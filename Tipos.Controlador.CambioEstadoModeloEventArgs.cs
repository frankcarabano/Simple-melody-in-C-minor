using System;

namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------------------
      I n t e r f a z   p a r a   C o n t r o l a d o r M v c    
    -----------------------------------------------------------*/

  public class CambioEstadoModeloEventArgs : EventArgs {
    IAdaptadorPtyInf propiedad;
    object modelo;

    public CambioEstadoModeloEventArgs( IAdaptadorPtyInf propiedad, object modelo ) {
      this.propiedad = propiedad;
      this.modelo = modelo;
    }

    public IAdaptadorPtyInf PropiedadCambiada {
      get { return this.propiedad; }
    }

    public object Modelo {
      get { return this.modelo; }
    }

  }	//------- Fin clase CambioEstadoEventArgs	

}	//------- Fin ES.Tipos.Controlador.CambioEstadoModeloEventArgs.cs
