using System;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.EsquemaBasico.Aplicaciones {
  public delegate void PublicacionManejador( object sender, EventArgs args );

  public class Cartelera {
    public event PublicacionManejador MensajePublicado;
    IList<Mensaje> mensajes;

    public Cartelera() {
      this.mensajes = new List<Mensaje>();
    }

    public IIteradorLista<Mensaje> Iterador {
      get {
        return new IteradorLista<Mensaje>( this.mensajes );
      }
    }

    public void Publicar( Mensaje mensaje ) {
      this.mensajes.Add( mensaje );
      notificarPublicacion( mensaje );
    }

    void notificarPublicacion( Mensaje mensaje ) {
      if ( MensajePublicado != null ) {
        MensajePublicado( mensaje, null );
      }
    }

  }  //------- Fin clase Cartelera

}  //------- Fin ES.Aplicaciones.Cartelera.cs
