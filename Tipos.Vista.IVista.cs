using System;

namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------
      I n t e r f a z   p a r a   V i s t a s    
    -------------------------------------------*/

  public interface IVista {
    bool EstadoEditado { get; }
    bool ConfirmacionSalida { get; }
    void EstablecerModelo( object modelo );
    void ReflejarModelo();
    void Advertir( string mensaje );
    void Informar( string mensaje );
    void IndicarResultadoValidacion( object widget, ApplicationException e );
    bool ConfirmarIntencion( string accion, string mensaje );
    void Editar( bool limpiar );
  }

}	// Fin ES.Tipos.Vista.IVista.cs
