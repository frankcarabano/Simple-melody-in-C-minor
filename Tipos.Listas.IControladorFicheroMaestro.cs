using System;

namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------------------------
     E s t a d o s   d e   e d i c i o n   d e   f i c h e r o s 
    -------------------------------------------------------------*/

  public enum EstadosEdicionFichero { Espera, Creando, Editando, Navegando }

  /*-----------------------------------------------------------------------------------
     E s t a d o s   d e   e d i c i o n   d e   e l e m e n t o s / r e g i s t r o s 
    -----------------------------------------------------------------------------------*/

  public enum EstadosEdicionInstancias { Nulo, Nuevo, Duplicado, Existente, Guardado }

  /*---------------------------------------------------
     I n t e r f a z   p a r a   C o n t r o l a d o r 
           d e   A r c h i v o s   M a e s t r o s         
    ----------------------------------------------------*/

  public interface IControladorFicheroMaestro {
    EstadosEdicionFichero EstadoEdicionFichero { get; }
    EstadosEdicionInstancias EstadoEdicionInstancia { get; }
    string NombreInstancia { get; }
    int ConteoLista { get; }
    int PosicionLista { get; }
    void ModeloCambioEstado( object sender, CambioEstadoModeloEventArgs args );
    void IntentoCancelarEdicion( object sender, EventArgs args );
    void ComandoSeleccionado( int indice );
  }

}	//------- Fin ES.Tipos.Listas.IControladorFicheroMaestro.cs
