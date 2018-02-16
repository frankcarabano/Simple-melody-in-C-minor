using System;

namespace Ekia.EsquemaBasico.Aplicaciones {
  /* ---------------------------------------------------------
      C L A S E   B A S E   P A R A   A P L I C A C I O N E S 
     ---------------------------------------------------------*/

  public abstract class Aplicacion : IAplicacion {
    protected IConfiguracion configuracion;
    protected IVistaCartelera vistaCartelera;
    protected Cartelera cartelera;

    public Aplicacion( IVistaCartelera vista ) {
      if ( vista != null ) {
        inicializarCartelera( vista );
      }
      else {
        this.vistaCartelera = null;
        this.cartelera = null;
      }
    }

    public Cartelera Cartelera {
      get { return this.cartelera; }
    }

    public abstract void Iniciar();
    public abstract void Terminar();

    void publicacionMensaje( object sender, EventArgs args ) {
      actualizarCartelera();
    }

    void atencionMensaje( object sender, EventArgs args ) {
      actualizarCartelera();
    }

    void actualizarCartelera() {
      this.vistaCartelera.ReflejarMensajes( this.cartelera.Iterador );
    }

    void inicializarCartelera( IVistaCartelera vista ) {
      this.cartelera = new Cartelera();
      this.cartelera.MensajePublicado += publicacionMensaje;
      this.vistaCartelera = vista;
      this.vistaCartelera.MensajeAtendido += atencionMensaje;
    }

  }	//------- Fin clase Aplicacion

}	//------- Fin ES.Aplicaciones.Aplicacion.cs