using System;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Listas {
  /*-------------------------------------------------------
     C l a s e   b a s e   p a r a   c o n t r o l a d o r 
          d e   P r o p i e d a d e s   -   L i s t a             
    -------------------------------------------------------*/

  public delegate void ActualizacionListaManejador( object sender, EventArgs args );

  public abstract class ControladorPropiedadLista<TInstancia> : IControladorPropiedadLista<TInstancia> {
    protected bool esNuevaInstancia;
    protected IPropiedadLista<TInstancia> lista;
    protected IControladorMV controladorMV;
    protected IAdaptadorVista<TInstancia> vista;
    protected TInstancia bufferInstancias;
    protected string claveInstanciaActual;
    public event ActualizacionListaManejador ActualizacionLista;

    public ControladorPropiedadLista( IControladorMV controladorMV, IAdaptadorVista<TInstancia> vista ) {
      this.claveInstanciaActual = null;
      this.controladorMV = controladorMV;
      this.vista = vista;
      this.vista.EstablecerControlLista( this );
    }

    public ControladorPropiedadLista( IPropiedadLista<TInstancia> lista, IControladorMV controladorMV, IAdaptadorVista<TInstancia> vista ) :
                                this( controladorMV, vista ) {
      establecerLista( lista );
    }

    public IIteradorLista<TInstancia> IteradorLista {
      get {
        IIteradorLista<TInstancia> iterador = null;
        if ( this.lista != null ) {
          iterador = this.lista.Iterador;
        }
        return iterador;
      }
    }

    public bool EsNuevaInstancia {
      get { return this.esNuevaInstancia; }
    }

    public TInstancia InstanciaActual {
      get { return this.bufferInstancias; }
    }

    public void EstablecerLista( IPropiedadLista<TInstancia> lista ) {
      establecerLista( lista );
    }

    public virtual void ActualizarLista( object sender, EventArgs args ) { }

    public virtual void SeleccionarInstancia( string clave ) {
      this.esNuevaInstancia = false;
      this.claveInstanciaActual = clave;
      copiarInstanciaAlBuffer( clave );
      establecerModelo();
    }

    public virtual void EliminarInstancia( object sender, EventArgs args ) {
      if ( !this.esNuevaInstancia ) {
        this.lista.EliminarInstancia( this.claveInstanciaActual );
        notificarActualizacion();
        crearNuevaInstancia();
      }
    }

    protected void establecerModelo() {
      this.controladorMV.EstablecerModelo( this.bufferInstancias );
      this.controladorMV.LimpiarModelo();
      this.vista.EstablecerModelo( this.bufferInstancias );
    }

    protected void actualizarClave() {
      this.lista.EliminarInstancia( this.claveInstanciaActual );
      this.lista.IncluirInstancia( this.bufferInstancias );
    }

    protected void notificarActualizacion() {
      if ( this.ActualizacionLista != null ) {
        ActualizacionLista( this, null );
      }
    }

    protected void crearNuevaInstancia() {
      this.bufferInstancias = crearInstancia();
      this.esNuevaInstancia = true;
      establecerModelo();
      this.vista.Editar( true );
    }

    protected bool claveEditada() {
      return this.claveInstanciaActual != Reflector.ObtenerValorPropiedad( this.bufferInstancias,
                                                                            this.lista.NombreClave ).ToString();
    }

    protected abstract TInstancia crearInstancia();
    protected abstract void copiarInstanciaAlBuffer( string clave );
    protected abstract void actualizarInstancia();

    void establecerLista( IPropiedadLista<TInstancia> lista ) {
      this.lista = lista;
      crearNuevaInstancia();
    }

  }	//------- Fin clase ControladorPropiedadLista

}	//------- Fin ES.Listas.ControladorPropiedadLista.cs