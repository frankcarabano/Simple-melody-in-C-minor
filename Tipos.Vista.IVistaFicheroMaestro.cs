using System.Collections;

namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------
        I n t e r f a z   p a r a   V i s t a s      
     d e   e d i c i o n   d e   m u l t i p l e s 
        i n s t a n c i a s / r e g i s t r o s    
    -----------------------------------------------*/

  public interface IVistaFicheroMaestro : IVista {
    void CancelarEdicion( bool limpiar );
    void EstablecerControlFichero( IControladorFicheroMaestro control );
    void ReflejarEstadoEdicion();
    object SeleccionarInstancia( ICollection lista );
  }

}	// Fin ES.Tipos.Vista.IVistaFicheroMestro.cs
