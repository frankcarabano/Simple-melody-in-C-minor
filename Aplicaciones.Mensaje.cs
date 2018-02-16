
namespace Ekia.EsquemaBasico.Aplicaciones {
  public delegate void AtencionMensaje( Mensaje mensaje );

  public class Mensaje {
    string texto;
    object objeto;
    string tema;
    AtencionMensaje atencion;
    bool atendido;

    public Mensaje( string tema, string texto, object objeto, AtencionMensaje atencion ) {
      this.tema = tema;
      this.texto = texto;
      this.objeto = objeto;
      this.atencion = atencion;
      this.atendido = false;
    }

    public string Texto {
      get { return this.texto; }
    }

    public object Objeto {
      get { return this.objeto; }
    }

    public string Tema {
      get { return this.tema; }
    }

    public bool Atendido {
      get { return this.atendido; }
    }

    public void Atender() {
      if ( this.atencion != null ) {
        this.atendido = true;
        this.atencion( this );
      }
    }

  }  //------- Fin clase MensajeUsuario

}  //------- Fin ES.Aplicaciones.MensajeUsuario.cs
