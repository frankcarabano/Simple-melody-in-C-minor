using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaWinForms {
  /*---------------------------------------------------------------------
    C l a s e   V i s t a   p a r a   C u a d r o s   d e   d i á l o g o
        d e   e d i c i ó n   d e   F i c h e r o s   M a e s t r o s
       ( b a s a d a   e n   S y s t e m . W i n d o w s . F o r m s )  
    ---------------------------------------------------------------------*/

  public delegate void IntencionCancelarManejador( object sender, EventArgs args );

  public partial class VistaFicheroMaestroWf : VistaWf, IVistaFicheroMaestro {
    //------- C a m p o s   p r i v a d o s -------//
    const int ESC = 27;
    bool edicionBloqueada;
    Color colorEtiquetasActivas;
    //------	C a m p o s   p r o t e g i d o s ------//
    protected int proximoIndice;
    protected VistaSeleccionWf vistaSeleccion;
    protected IControladorFicheroMaestro controlFichero;
    public event IntencionCancelarManejador IntencionCancelarEdicion;

    //---------------------------------//
    //    C o n s t r u c t o r e s    //
    //---------------------------------//

    // Este constructor es necesario para tener habilitado el diseñador visual

    public VistaFicheroMaestroWf() : base() {
      InitializeComponent();
    }

    public VistaFicheroMaestroWf( ControladorMvWf ctrl, VistaSeleccionWf vistaSel, Color colorEtiqAct ) : base( ctrl, true ) {
      InitializeComponent();
      inicializar( vistaSel );
      colorEtiquetasActivas = colorEtiqAct;
    }

    public VistaFicheroMaestroWf( ControladorMvWf ctrl, VistaSeleccionWf vistaSel, object mdlo, Color colorEtiqAct ) : base( ctrl, true, mdlo ) {
      InitializeComponent();
      inicializar( vistaSel );
      colorEtiquetasActivas = colorEtiqAct;
    }


    //-----------------------------//
    //    P r o p i e d a d e s    //
    //-----------------------------//

    // Imágenes para botones de la barra de herramientas

    public Image ImagenBotonInicio {
      get { return botonInicio.Image; }
      set { botonInicio.Image = value; }
    }

    public Image ImagenBotonPrevio {
      get { return botonPrevio.Image; }
      set { botonPrevio.Image = value; }
    }

    public Image ImagenBotonSiguiente {
      get { return botonSiguiente.Image; }
      set { botonSiguiente.Image = value; }
    }

    public Image ImagenBotonFinal {
      get { return botonFinal.Image; }
      set { botonFinal.Image = value; }
    }

    public Image ImagenBotonCrear {
      get { return botonCrear.Image; }
      set { botonCrear.Image = value; }
    }

    public Image ImagenBotonDuplicar {
      get { return botonDuplicar.Image; }
      set { botonDuplicar.Image = value; }
    }

    public Image ImagenBotonBuscar {
      get { return botonBuscar.Image; }
      set { botonBuscar.Image = value; }
    }

    public Image ImagenBotonModificar {
      get { return botonModificar.Image; }
      set { botonModificar.Image = value; }
    }

    public Image ImagenBotonArchivar {
      get { return botonArchivar.Image; }
      set { botonArchivar.Image = value; }
    }

    public Image ImagenBotonEliminar {
      get { return botonEliminar.Image; }
      set { botonEliminar.Image = value; }
    }

    // Manejador de eventos de la barra de herramientas

    public ToolStripItemClickedEventHandler ManejadorBarraHerramientas {
      set { this.barraHerramientas.ItemClicked += value; }
    }


    //---------------------------------------//
    //    M é t o d o s   p ú b l i c o s    //
    //---------------------------------------//

    // Establecer Controlador de Lista interno

    public void EstablecerControlFichero( IControladorFicheroMaestro ctrl ) {
      this.controlFichero = ctrl;
      this.IntencionCancelarEdicion += new IntencionCancelarManejador( this.controlFichero.IntentoCancelarEdicion );
    }

    // Reflejar el estado de la edición de la lista

    public void ReflejarEstadoEdicion() {
      reflejarCuenta();
      reflejarEstado();
    }

    // Seleccionar un elemento a través del cuadro de diálogo de búsqueda

    public virtual object SeleccionarInstancia( System.Collections.ICollection lista ) {
      this.vistaSeleccion.Lista = lista;
      DialogResult dr = this.vistaSeleccion.ShowDialog();
      return this.vistaSeleccion.Seleccion;
    }

    // Habilitar edición del Modelo

    public override void Editar( bool limpiar ) {
      this.estadoEditado = false;
      establecerBloqueoEdicion( false );
      colorearEtiquetas( colorEtiquetasActivas );
      conmutarTabStops( true );
      if ( limpiar ) {
        limpiarControlesEdicion();
      }
      focoEnPrimerControl( this.contenedoresEdicion[0] );
    }

    // Deshabilitar edición del Modelo

    public virtual void CancelarEdicion( bool limpiar ) {
      establecerBloqueoEdicion( true );
      colorearEtiquetas( SystemColors.GrayText );
      conmutarTabStops( false );
      if ( limpiar ) {
        limpiarControlesEdicion();
      }
      this.Nula.Focus();
      this.estadoEditado = false;
    }

    // Indicar el resultado de la validación del modelo, actualizando la habilitación de los botones de la barra

    public override void IndicarResultadoValidacion( object widget, ApplicationException e ) {
      habilitarBarra();
      base.IndicarResultadoValidacion( widget, e );
    }


    //---------------------------------------------------------//
    //       M a n e j a d o r e s   d e   e v e n t o s       //
    //---------------------------------------------------------//

    /*   M a n e j o   d e   t e c l a d o   */

    void CapturaTeclado( object sender, KeyEventArgs args ) {
      // Si ha sido pulsada la tecla Esc y la edición está en curso confirmar el abandono de la misma
      if ( args.KeyValue == ESC && !edicionBloqueada ) {
        IntencionCancelarEdicion( this, null );
      }
      // Si ha sido usada una combinación Ctrl-Tecla invocar el comando correspondiente
      if ( args.Control ) {
        IList<ToolStripButton> botones1 = (IList<ToolStripButton>)this.barraHerramientas.Tag;
        IDictionary<string, ToolStripButton> botones2 = (IDictionary<string, ToolStripButton>)this.Tag;
        string tecla = args.KeyCode.ToString();
        if ( "IPSFCDBMAE".IndexOf( tecla ) >= 0 ) {
          if ( botones2[tecla].Enabled ) {
            this.controlFichero.ComandoSeleccionado( botones1.IndexOf( botones2[tecla] ) );
          }
        }
      }
      /* Si la edición está bloqueada 'SuppressKeyPress = true' evita que la información
         de teclado llegue al correspondiente control ---------------------------------- */
      if ( edicionBloqueada ) {
        args.SuppressKeyPress = true;
      }
    }

    /* M a n e j o   d e   r a t ó n   c u a n d o   e d i c i o n B l o q u e a d a   e s   T r u e
       Debe ser asignado al evento MouseDown de los controles de edición  */

    protected void RatonEnControlEdicion( object sender, MouseEventArgs e ) {
      if ( focoEdicion() && ( this.edicionBloqueada ) ) {
        this.Nula.Focus();
      }
    }


    //-------------------------------------------------//
    //       M é t o d o s   p r o t e g i d o s       //
    //-------------------------------------------------//

    // Establecer si la edición estará o no bloqueada

    protected void establecerBloqueoEdicion( bool bloqueada ) {
      this.edicionBloqueada = bloqueada;
    }

    // Colorear etiquetas de controles en contenedores de edición

    protected void colorearEtiquetas( Color color ) {
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        colorearEtiquetasContenedor( contenedor, color );
      }
    }

    // Colorear las etiquetas de un contenedor

    protected void colorearEtiquetasContenedor( System.Windows.Forms.Control contenedor, Color color ) {
      foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
        if ( ctrl.Controls.Count > 0 ) {
          colorearEtiquetasContenedor( ctrl, color );
        }
        else if ( ctrl is System.Windows.Forms.Label ) {
          if ( ctrl.Tag == null ) {
            ( ctrl as System.Windows.Forms.Label ).ForeColor = color;
          }
        }
      }
    }

    // Conmutar propiedad TabStop de controles en contenedor de edición

    protected void conmutarTabStops( bool usaTab ) {
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        conmutarTabStopsContenedor( contenedor, usaTab );
      }
    }

    // Habilitar botones de la barra de herramientas según el Estado de la Lista

    protected virtual void habilitarBarra() {
      switch ( this.controlFichero.EstadoEdicionFichero ) {
        case EstadosEdicionFichero.Creando:
        case EstadosEdicionFichero.Editando:
          this.botonCrear.Enabled = false;
          this.botonDuplicar.Enabled = false;
          this.botonBuscar.Enabled = false;
          this.botonModificar.Enabled = false;
          this.botonArchivar.Enabled = ( this.ctrlMv.EstadoModeloEditado && this.ctrlMv.EstadoModeloValido );
          this.botonEliminar.Enabled = false;
          this.botonInicio.Enabled = false;
          this.botonPrevio.Enabled = false;
          this.botonSiguiente.Enabled = false;
          this.botonFinal.Enabled = false;
          break;
        case EstadosEdicionFichero.Espera:
        case EstadosEdicionFichero.Navegando:
          this.botonCrear.Enabled = true;
          this.botonDuplicar.Enabled = ( ( this.modelo != null ) &&
                                         ( ( this.controlFichero.EstadoEdicionInstancia == EstadosEdicionInstancias.Guardado ) ||
                                         ( this.controlFichero.EstadoEdicionInstancia == EstadosEdicionInstancias.Existente ) ) );
          this.botonBuscar.Enabled = ( this.controlFichero.ConteoLista > 0 );
          this.botonModificar.Enabled = this.botonDuplicar.Enabled;
          this.botonArchivar.Enabled = false;
          this.botonEliminar.Enabled = this.botonDuplicar.Enabled;
          habilitarBotonesNavegacion();
          break;
      }
    }

    // Habilitar botones de navegación de la barra de herramientas según el conteo de elementos de la Lista

    protected virtual void habilitarBotonesNavegacion() {
      if ( this.controlFichero.ConteoLista > 1 ) {
        this.botonInicio.Enabled = ( this.controlFichero.PosicionLista > 1 );
        this.botonPrevio.Enabled = this.botonInicio.Enabled;
        this.botonSiguiente.Enabled = ( this.controlFichero.PosicionLista < this.controlFichero.ConteoLista );
        this.botonFinal.Enabled = this.botonSiguiente.Enabled;
      }
      else {
        this.botonInicio.Enabled = this.botonPrevio.Enabled =
        this.botonSiguiente.Enabled = this.botonFinal.Enabled = false;
      }
    }


    //---------------------------------------//
    //    M é t o d o s   p r i v a d o s    //
    //---------------------------------------//

    // Conmutar Tabstops de un contenedor

    void conmutarTabStopsContenedor( System.Windows.Forms.Control contenedor, bool usaTab ) {
      foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
        if ( ctrl.Controls.Count > 0 ) {
          conmutarTabStopsContenedor( ctrl, usaTab );
        }
        else {
          ctrl.TabStop = usaTab;
        }
      }
    }

    // Determinar si hay foco en un control de edición

    bool focoEdicion() {
      bool hayFoco = false;
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
          if ( ctrl.Focused ) {
            hayFoco = true;
            break;
          }
        }
        if ( hayFoco ) break;
      }
      return hayFoco;
    }

    // Reflejar el conteo de elementos de la Lista

    void reflejarCuenta() {
      string texto = "|   ";
      bool plural = false;
      if ( this.controlFichero.ConteoLista > 0 ) {
        texto += this.controlFichero.ConteoLista.ToString() + " " + this.controlFichero.NombreInstancia;
        plural = this.controlFichero.ConteoLista > 1;
      }
      else {
        texto += "No hay " + this.controlFichero.NombreInstancia;
        plural = true;
      }
      if ( plural ) {
        if ( ( this.controlFichero.NombreInstancia.EndsWith( "r" ) ) || ( this.controlFichero.NombreInstancia.EndsWith( "n" ) ) ) {
          texto += "es";
        }
        else {
          texto += "s";
        }
      }
      this.cuentaRegistros.Text = texto;
    }

    // Reflejar el Estado de edición de la Lista

    void reflejarEstado() {
      const string MENSAJE_CANCELAR = "Pulse Esc para cancelar   |";
      string ayuda = string.Empty;
      string status = string.Empty;
      switch ( this.controlFichero.EstadoEdicionFichero ) {
        case EstadosEdicionFichero.Creando:
          if ( this.controlFichero.EstadoEdicionInstancia == EstadosEdicionInstancias.Nuevo ) {
            status = "Nuevo(a) " + this.controlFichero.NombreInstancia;
          }
          else {
            status = "Duplicado de " + this.controlFichero.NombreInstancia;
          }
          ayuda = MENSAJE_CANCELAR;
          break;
        case EstadosEdicionFichero.Editando:
          status = "Editando información de " + this.controlFichero.NombreInstancia;
          ayuda = MENSAJE_CANCELAR;
          break;
        case EstadosEdicionFichero.Espera:
        case EstadosEdicionFichero.Navegando:
          if ( this.controlFichero.ConteoLista > 0 ) {
            status = this.controlFichero.NombreInstancia + " nro. " + this.controlFichero.PosicionLista.ToString();
          }
          break;
      }
      this.statusControlador.Text = status;
      this.ayudaEdicion.Text = ayuda;
      habilitarBarra();
    }

    /* Indizar los botones de la barra de herramientas en un IList genérico referenciado en el Tag de la barra,
         y en un IDictionary referenciado en el Tag del Form ---------------------------------------------------- */

    void indizarBotonesBarra() {
      IList<ToolStripButton> botonesBarra1 = new List<ToolStripButton>();
      IDictionary<string, ToolStripButton> botonesBarra2 = new Dictionary<string, ToolStripButton>();
      foreach ( ToolStripItem tsi in this.barraHerramientas.Items ) {
        if ( tsi is ToolStripButton ) botonesBarra1.Add( tsi as ToolStripButton );
      }
      botonesBarra2.Add( "I", botonInicio );
      botonesBarra2.Add( "P", botonPrevio );
      botonesBarra2.Add( "S", botonSiguiente );
      botonesBarra2.Add( "F", botonFinal );
      botonesBarra2.Add( "C", botonCrear );
      botonesBarra2.Add( "D", botonDuplicar );
      botonesBarra2.Add( "B", botonBuscar );
      botonesBarra2.Add( "M", botonModificar );
      botonesBarra2.Add( "A", botonArchivar );
      botonesBarra2.Add( "E", botonEliminar );
      this.barraHerramientas.Tag = botonesBarra1;
      this.Tag = botonesBarra2;
    }

    // Inicializar instancias

    void inicializar( VistaSeleccionWf vistaSel ) {
      indizarBotonesBarra();
      this.KeyPreview = true;
      this.KeyDown += new KeyEventHandler( CapturaTeclado );
      this.edicionBloqueada = false;
      this.vistaSeleccion = vistaSel;
      this.controlFichero = null;
    }

  }	//------- Fin Clase VistaFicheroMaestroWf

}	//------- Fin ES.EsquemaWf.VistaFicheroMaestroWf.cs