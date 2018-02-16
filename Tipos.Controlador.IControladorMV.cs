using System;

namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------------------
      I n t e r f a z   p a r a   C o n t r o l a d o r M v c    
    -----------------------------------------------------------*/

  public interface IControladorMV {
    bool EstadoModeloEditado { get; }
    bool EstadoModeloValido { get; }
    bool EdicionActiva { get; }
    void EstablecerVista( IVista vist );
    void EstablecerModelo( object mdlo );
    void LimpiarModelo();
    void ActivarEdicion();
    void DesactivarEdicion();
    void ActualizarModelo( object widget, EventArgs args );
    event CambioEstadoModeloManejador CambioEstadoModelo;
  }

  public delegate void CambioEstadoModeloManejador( object sender, CambioEstadoModeloEventArgs args );

}	//------- Fin ES.Tipos.Controlador.IControladorMV.cs
