using System;
using System.Collections;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Listas {
  /*------------------------------------------------------------
     C l a s e    b a s e   p a r a   C o n t r o l a d o r e s 
              d e   F i c h e r o s   m a e s t r o s           
    ------------------------------------------------------------*/

  public abstract class ControladorFicheroMaestro<TInstancia> : IControladorFicheroMaestro {
    protected EstadosEdicionFichero estadoEdicionFichero;
    protected EstadosEdicionInstancias estadoEdicionInstancia;
    protected IComando[] comandos;
    protected IFicheroMaestro<TInstancia> fichero;
    protected INavegadorFicheroMaestro<TInstancia> navegador;
    protected IVistaFicheroMaestro vista;
    protected IControladorMV controladorMV;
    protected TInstancia bufferInstancia;
    protected string nombreInstancia;
    protected IMemento memento;

    // ***	C O N S T R U C T O R	*** //

    public ControladorFicheroMaestro( IFicheroMaestro<TInstancia> fichero, 
                                      string nombIns,
                                      IControladorMV ctrlMV,
                                      IVistaFicheroMaestro vist ) {
      inicializar( fichero, nombIns, ctrlMV, vist );
    }

    // *** P R O P I E D A D E S *** //

    public TInstancia ElementoActual {
      get { return this.bufferInstancia; }
    }

    public EstadosEdicionFichero EstadoEdicionFichero {
      get { return this.estadoEdicionFichero; }
    }

    public EstadosEdicionInstancias EstadoEdicionInstancia {
      get { return this.estadoEdicionInstancia; }
    }

    public string NombreInstancia {
      get { return this.nombreInstancia; }
    }

    public int ConteoLista {
      get { return this.fichero.Conteo; }
    }

    public int PosicionLista {
      get { return this.navegador.Posicion; }
    }


    // ***	M E T O D O S   P U B L I C O S		*** //      

    public void ModeloCambioEstado( object sender, CambioEstadoModeloEventArgs args ) {
      this.vista.ReflejarEstadoEdicion();
    }

    public void IntentoCancelarEdicion( object sender, EventArgs args ) {
      string accion = "Cancelar edición";
      string mensaje = crearMensajeCancelacion();
      if ( this.vista.ConfirmarIntencion( accion, mensaje ) ) {
        this.cancelarEdicion();
      }
    }

    public void ComandoSeleccionado( int indice ) {
      this.comandos[indice].Ejecutar();
    }


    // ***	M E T O D O S   P R O T E G I D O S		*** //

    protected internal virtual void CrearInstancia() {
      CrearMemento();											                    // establecer memento
      establecerEstadoCreacion( false );						          // establecer el estado del controlador
      establecerInstancia( this.fichero.CrearInstancia() );   // crear elemento y establecerlo como el elemento actual
      if ( this.navegador == null ) crearIterador();		      // crear iterador si aún no ha sido instanciado
      this.controladorMV.DesactivarEdicion();			            // desactivar edición en el Controlador modelo-vista
      this.vista.Editar( true );								              // activar edición el la Vista, limpiando los widgets
      this.controladorMV.ActivarEdicion();				            // activar edición en el Controlador modelo-vista
    }

    protected internal virtual void DuplicarInstancia() {
      CrearMemento();
      establecerEstadoCreacion( true );
      establecerInstancia( duplicarInstancia() );
      this.controladorMV.DesactivarEdicion();
      this.vista.ReflejarModelo();
      this.vista.Editar( false );
      this.controladorMV.ActivarEdicion();
    }

    protected internal virtual void RecuperarInstancia() {
      object seleccionado = this.vista.SeleccionarInstancia( this.fichero.Lista as ICollection );
      if ( seleccionado != null ) {
        establecerEstadoNavegacion();
        establecerInstancia( seleccionado );
      }
    }

    protected internal virtual void EditarInstancia() {
      CrearMemento();
      establecerEstadoEdicion();
      this.controladorMV.LimpiarModelo();
      this.vista.Editar( false );
      this.controladorMV.ActivarEdicion();
    }

    protected internal virtual void GuardarInstancia() {
      if ( actualizarFichero() ) {
        try {
          this.fichero.GuardarInstancia( this.bufferInstancia );
          if ( this.estadoEdicionInstancia != EstadosEdicionInstancias.Existente ) IrUltimaInstancia();
          establecerEstadoGuardado();
          this.memento = null;
          this.controladorMV.LimpiarModelo();
          this.controladorMV.DesactivarEdicion();
          this.vista.CancelarEdicion( false );
        }
        catch ( ApplicationException e ) {
          this.vista.Informar( e.Message );
        }
      }
    }

    protected internal virtual void EliminarInstancia() {
      string accion = "Eliminación";
      string mensaje = crearMensajeEliminacion( false );
      if ( this.vista.ConfirmarIntencion( accion, mensaje ) ) {
        if ( eliminarInstancia() ) {
          this.vista.Informar( crearMensajeEliminacion( true ) );
          if ( this.fichero.EstaVacante ) {
            establecerEstadoVacio();
          }
          else {
            establecerEstadoNavegacion();
            establecerInstancia( this.navegador.Actual() );
          }
          this.controladorMV.DesactivarEdicion();
          this.vista.CancelarEdicion( this.fichero.EstaVacante );
        }
      }
    }

    protected internal virtual void IrPrimeraInstancia() {
      establecerEstadoNavegacion();
      establecerInstancia( this.navegador.Primera() );
    }

    protected internal virtual void IrInstanciaAnterior() {
      establecerEstadoNavegacion();
      establecerInstancia( ( this.navegador.Anterior() ) );
    }

    protected internal virtual void IrInstanciaSiguiente() {
      establecerEstadoNavegacion();
      establecerInstancia( this.navegador.Siguiente() );
    }

    protected internal virtual void IrUltimaInstancia() {
      establecerEstadoNavegacion();
      establecerInstancia( this.navegador.Ultima() );
    }

    protected internal virtual void IrInstancia( int indice ) {
      establecerEstadoNavegacion();
      establecerInstancia( this.navegador.Instancia( indice ) );
    }

    protected virtual bool eliminarInstancia() {
      bool eliminada = false;
      try {
        this.fichero.EliminarInstancia( this.bufferInstancia );
        eliminada = true;
      }
      catch ( ApplicationException e ) {
        vista.Informar( e.Message );
      }
      return eliminada;
    }

    protected void cancelarEdicion() {
      this.controladorMV.DesactivarEdicion();
      establecerMemento();
      if ( this.estadoEdicionInstancia != EstadosEdicionInstancias.Nulo ) this.vista.ReflejarModelo();
      this.controladorMV.LimpiarModelo();
      this.vista.CancelarEdicion( this.estadoEdicionInstancia == EstadosEdicionInstancias.Nulo );
      this.vista.ReflejarEstadoEdicion();
      this.memento = null;
    }

    protected virtual void establecerInstancia( object instancia ) {
      this.bufferInstancia = (TInstancia)instancia;
      establecerInstanciaModelo( instancia );
    }

    protected string crearMensajeCancelacion() {
      string mensaje = "Va a ser suspendido el proceso de ";
      switch ( this.estadoEdicionFichero ) {
        case EstadosEdicionFichero.Creando:
          mensaje += "crear este(a) nuevo(a) " + nombreInstancia;
          break;
        case EstadosEdicionFichero.Editando:
          mensaje += "editar los datos de este(a) " + nombreInstancia;
          break;
      }
      mensaje += ". ¿Desea proceder?";
      return mensaje;
    }

    protected string crearMensajeEliminacion( bool ejecutada ) {
      string mensaje = string.Empty;
      if ( !ejecutada ) {
        mensaje = "Va a ser eliminado(a) este(a) " + nombreInstancia + ". ¿Desea proceder?";
      }
      else {
        mensaje = nombreInstancia + " eliminado(a)";
      }
      return mensaje;
    }

    protected void establecerEstadoEspera( bool existeElemento ) {
      this.estadoEdicionFichero = EstadosEdicionFichero.Espera;
      this.estadoEdicionInstancia = existeElemento ? EstadosEdicionInstancias.Existente : EstadosEdicionInstancias.Nulo;
    }

    protected void establecerEstadoCreacion( bool esDuplicado ) {
      this.estadoEdicionFichero = EstadosEdicionFichero.Creando;
      this.estadoEdicionInstancia = esDuplicado ? EstadosEdicionInstancias.Duplicado : EstadosEdicionInstancias.Nuevo;
    }

    protected void establecerEstadoEdicion() {
      this.estadoEdicionFichero = EstadosEdicionFichero.Editando;
      this.estadoEdicionInstancia = EstadosEdicionInstancias.Existente;
    }

    protected void establecerEstadoNavegacion() {
      this.estadoEdicionFichero = EstadosEdicionFichero.Navegando;
      this.estadoEdicionInstancia = EstadosEdicionInstancias.Existente;
    }

    protected void establecerEstadoGuardado() {
      this.estadoEdicionFichero = EstadosEdicionFichero.Espera;
      this.estadoEdicionInstancia = EstadosEdicionInstancias.Guardado;
    }

    protected void CrearMemento() {
      this.memento = crearMemento();
      this.memento.GuardarEstado( this );
    }

    protected abstract IMemento crearMemento();
    protected abstract void establecerMemento();
    protected abstract void anularInstancia();
    protected abstract void asociarComandos();


    // ***	M E T O D O S   P R I V A D O S	*** //

    void inicializar( IFicheroMaestro<TInstancia> fichero,
                     string nombIns,
                     IControladorMV ctrlMV,
                     IVistaFicheroMaestro vist ) {
      establecerParametros( fichero, nombIns, ctrlMV, vist );
      this.controladorMV.DesactivarEdicion();
      establecerEstadoInicial();
      asociarComandos();
      this.vista.CancelarEdicion( this.estadoEdicionInstancia == EstadosEdicionInstancias.Nulo );
      this.vista.ReflejarEstadoEdicion();
    }

    void establecerParametros( IFicheroMaestro<TInstancia> fichero,
                              string nombIns,
                              IControladorMV ctrlMV,
                              IVistaFicheroMaestro vist ) {
      this.fichero = fichero;
      this.navegador = null;
      this.nombreInstancia = nombIns;
      this.memento = null;
      this.controladorMV = ctrlMV;
      this.controladorMV.CambioEstadoModelo += new CambioEstadoModeloManejador( ModeloCambioEstado );
      this.vista = vist;
      this.vista.EstablecerControlFichero( this );
    }

    void establecerEstadoInicial() {
      if ( this.fichero.EstaVacante ) {         // si el fichero está vacío
        establecerEstadoVacio();
      }
      else {                                    // si el fichero contiene elementos
        crearIterador();
        establecerEstadoEspera( true );
        establecerInstancia( this.navegador.Primera() );
        this.vista.ReflejarModelo();
      }
    }

    void establecerEstadoVacio() {
      establecerEstadoEspera( false );
      establecerInstancia( null );
    }

    bool actualizarFichero() {
      bool actualizado = false;
      // si es un elemento nuevo (sea completamente nuevo o duplicado)
      if ( this.estadoEdicionInstancia == EstadosEdicionInstancias.Nuevo || this.estadoEdicionInstancia == EstadosEdicionInstancias.Duplicado ) {
        actualizado = incluirInstancia();
      }
      // si es un elemento existente
      else {
        actualizado = actualizarInstancia();
      }
      return actualizado;
    }

    bool incluirInstancia() {
      bool incluida = false;
      try {
        this.fichero.IncluirInstancia( this.bufferInstancia );
        incluida = true;
      }
      catch ( ClaveDuplicada e ) {
        this.vista.Informar( e.Message );
      }
      return incluida;
    }

    bool actualizarInstancia() {
      bool actualizado = false;
      string clave = claveElemento( this.bufferInstancia );
      if ( claveEditada( clave ) ) {
        if ( this.fichero.ContieneClave( clave ) ) {
          this.vista.Informar( "Ya existe un(a) " + this.nombreInstancia + " identificado(a) con la clave '" + clave + "'" );
        }
        else {
          this.fichero.Indizar();
          actualizado = true;
        }
      }
      else {
        actualizado = true;
      }
      return actualizado;
    }

    TInstancia duplicarInstancia() {
      TInstancia duplicado = ( this.bufferInstancia as IClonable<TInstancia> ).Duplicar();
      Reflector.EstablecerValorPropiedad( duplicado, this.fichero.NombreClave, string.Empty );
      return duplicado;
    }

    void crearIterador() {
      this.navegador = new NavegadorFicheroMaestro<TInstancia>( this.fichero.Lista );
    }

    bool claveEditada( string clave ) {
      return clave != claveElemento( (TInstancia)( this.memento.ObtenerEstado() as EstadoControlador<TInstancia> ).Elemento );
    }

    void establecerInstanciaModelo( object elemento ) {
      this.vista.EstablecerModelo( elemento );
      this.controladorMV.EstablecerModelo( elemento );
      if ( elemento != null ) this.controladorMV.LimpiarModelo();
      if ( this.estadoEdicionFichero == EstadosEdicionFichero.Navegando && this.estadoEdicionInstancia == EstadosEdicionInstancias.Existente ) {
        this.controladorMV.DesactivarEdicion();
        this.vista.ReflejarModelo();
        this.vista.CancelarEdicion( false );
      }
    }

    string claveElemento( TInstancia elemento ) {
      return Reflector.ObtenerValorPropiedad( elemento, this.fichero.NombreClave ).ToString();
    }

  }	//------- Fin clase ControladorFicheroMaestro

}	//------- Fin ES.Listas.ControladorFicheroMaestro.cs