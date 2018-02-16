using System;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.EsquemaWinForms {
  /* -------------------------------------------------------
      A D A P T A D O R   D E   I N T E R F A Z   V I S T A 
      P A R A   C O N T R O L E S   C O N T E N E D O R E S 
        E N   L A   P L A T A F O R M A   W I N F O R M S   
     -------------------------------------------------------*/

  public delegate void VistaListaActualizadaManejador( object sender, EventArgs args );

  public abstract class AdaptadorVista<TInstancia> : IAdaptadorVista<TInstancia> {
    protected object modelo;
    protected System.Windows.Forms.Control contenedor;
    protected IVista vistaContenedora;
    protected ControladorMvWf controladorMV;
    protected IControladorPropiedadLista<TInstancia> controladorLista;
    protected System.Windows.Forms.ListView vistaLista;
    System.Windows.Forms.Button botonActualizar;
    System.Windows.Forms.ContextMenuStrip menuInstancias;
    bool estadoEditado;
    static bool limpiando;
    public event VistaListaActualizadaManejador VistaListaActualizada;

    //-----------------------------------//
    //       C o n s t r u c t o r       //
    //-----------------------------------//

    public AdaptadorVista( System.Windows.Forms.Control contenedor,
                           System.Windows.Forms.ListView vistaLista,
                           IVista vistaContenedora,
                           ControladorMvWf controladorMV ) {
      this.controladorMV = controladorMV;
      this.vistaContenedora = vistaContenedora;
      this.contenedor = contenedor;
      this.botonActualizar = (System.Windows.Forms.Button)this.contenedor.Controls["actualizarLista"];
      this.vistaLista = vistaLista;
      this.menuInstancias = this.vistaLista.ContextMenuStrip;
      this.estadoEditado = false;
      limpiando = false;
      this.vistaLista.SelectedIndexChanged += new EventHandler( SeleccionInstancia );
      this.controladorMV.EstablecerVista( this );
    }

    //-----------------------------------//
    //       P r o p i e d a d e s       //
    //-----------------------------------//

    public bool EstadoEditado {
      get { return this.estadoEditado; }
    }

    public bool ConfirmacionSalida {
      get { return false; }
    }

    public bool Limpiando {
      get { return limpiando; }
    }

    //----------------------------------------//
    //    M é t o d o s   p ú b l i c o s		//
    //----------------------------------------//

    public void EstablecerModelo( object mdlo ) {
      this.estadoEditado = false;
      this.modelo = mdlo;
      this.botonActualizar.Text = this.controladorLista.EsNuevaInstancia ? "Incluir" : "Actualizar";
    }

    public void ReflejarModelo() {
      reflejarModelo();
      habilitarBotonActualizar();
      this.estadoEditado = false;
    }

    public void Advertir( string mensaje ) {
      this.vistaContenedora.Advertir( mensaje );
    }

    public void Informar( string mensaje ) {
      this.vistaContenedora.Informar( mensaje );
    }

    public void IndicarResultadoValidacion( object widget, ApplicationException e ) {
      this.vistaContenedora.IndicarResultadoValidacion( widget, e );
    }

    public bool ConfirmarIntencion( string accion, string mensaje ) {
      return this.vistaContenedora.ConfirmarIntencion( accion, mensaje );
    }

    public virtual void Editar( bool limpiar ) {
      if ( limpiar ) limpiarControles();
      if ( this.contenedor.Tag != null ) {
        ( this.contenedor.Tag as System.Windows.Forms.Control ).Focus();
        ( this.contenedor.Tag as System.Windows.Forms.Control ).Select();
      }
    }

    public void EstablecerControlLista( IControladorPropiedadLista<TInstancia> controladorLista ) {
      this.controladorLista = controladorLista;
      conectarEventos();
    }

    //---------------------------------------------------//
    //    M a n e j a d o r e s   d e   e v e n t o s    //
    //---------------------------------------------------//

    // al seleccionar un item en el ListView

    public virtual void SeleccionInstancia( object sender, EventArgs args ) {
      bool haySeleccion = ( sender as System.Windows.Forms.ListView ).SelectedItems.Count > 0;
      this.menuInstancias.Items[0].Enabled = haySeleccion;
      if ( haySeleccion ) {
        this.controladorLista.SeleccionarInstancia( ( sender as System.Windows.Forms.ListView ).SelectedItems[0].Text );
        this.controladorMV.DesactivarEdicion();
        reflejarModelo();
        this.controladorMV.ActivarEdicion();
        Editar( false );
      }
    }

    public void ListaActualizada( object sender, EventArgs args ) {
      rellenarVistaLista();
      this.botonActualizar.Enabled = false;
      if ( this.VistaListaActualizada != null ) {
        VistaListaActualizada( this, null );
      }
    }

    //-------------------------------------------//
    //    M é t o d o s   p r o t e g i d o s		//
    //-------------------------------------------//

    protected void limpiarLista() {
      this.vistaLista.Items.Clear();
    }

    protected void establecerEstadoEditado() {
      this.estadoEditado = true;
    }

    protected void rellenarVistaLista() {
      limpiarLista();
      IIteradorLista<TInstancia> iterador = this.controladorLista.IteradorLista;
      if ( iterador.Conteo > 0 ) {
        iterador.Iniciar();
        while ( iterador.Iterar() ) {
          ListViewItem lvi = new ListViewItem();
          completarListViewItem( lvi, iterador.Actual );
          lvi.Tag = iterador.Actual;
          this.vistaLista.Items.Add( lvi );
        }
      }
    }

    protected abstract void reflejarModelo();
    protected abstract void habilitarBotonActualizar();
    protected virtual void completarListViewItem( ListViewItem lvi, TInstancia linea ) { }
    protected abstract void registrarControlesEdicion();
    protected abstract void limpiarControlesEdicion();

    //----------------------------------------//
    //    M é t o d o s   p r i v a d o s		//
    //----------------------------------------//

    void conectarEventos() {
      this.botonActualizar.Click += new EventHandler( this.controladorLista.ActualizarLista );
      this.menuInstancias.Items[0].Click += new EventHandler( this.controladorLista.EliminarInstancia );
      ( this.controladorLista as
      ControladorPropiedadLista<TInstancia> ).ActualizacionLista += new ActualizacionListaManejador( ListaActualizada );
    }

    void limpiarControles() {
      this.controladorMV.DesactivarEdicion();
      limpiando = true;
      limpiarControlesEdicion();
      limpiando = false;
      this.controladorMV.ActivarEdicion();
    }

  }	//------- Fin Clase AdaptadorVista

}	//------- Fin ES.AdaptadorVista.cs