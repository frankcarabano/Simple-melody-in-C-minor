using System;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Aplicaciones {
  /* --------------------------------------------------------
    I N T E R F A Z  P A R A   V I S T A C A R T E L E R A  
   ----------------------------------------------------------*/

  public delegate void AtencionMensajeManejador( object sender, EventArgs args );

  public interface IVistaCartelera {
    void ReflejarMensajes( IIteradorLista<Mensaje> iterador );
    event AtencionMensajeManejador MensajeAtendido;
  }

}	//------- Fin ES.Aplicaciones.Interfaces.IVistaCartelera.cs