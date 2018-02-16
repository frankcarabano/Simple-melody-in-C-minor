using System;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Aplicaciones;

namespace Ekia.EsquemaWinForms {
  public partial class VistaCarteleraWf : Form, IVistaCartelera {
    public event AtencionMensajeManejador MensajeAtendido;

    public VistaCarteleraWf() {
      InitializeComponent();
      configurarVistaMensajes();
    }

    public void ReflejarMensajes( IIteradorLista<Mensaje> iterador ) {
      this.vistaMensajes.Items.Clear();
      if ( iterador != null && iterador.Conteo > 0 ) {
        iterador.Iniciar();
        while ( iterador.Iterar() ) {
          if ( !iterador.Actual.Atendido ) {
            if ( !contieneTema( iterador.Actual.Tema ) ) {
              incluirTema( iterador.Actual.Tema );
            }
            incluirMensaje( iterador.Actual );
          }
        }
      }
    }

    protected virtual ListViewItem crearItem( Mensaje mensaje ) {
      return null;
    }

    void seleccionMensaje( object sender, EventArgs e ) {
      if ( ( sender as System.Windows.Forms.ListView ).SelectedItems[0] != null ) {
        Mensaje mensaje = (Mensaje)( sender as System.Windows.Forms.ListView ).SelectedItems[0].Tag;
        mensaje.Atender();
        notificarAtencionMensaje();
      }
    }

    bool contieneTema( string tema ) {
      return this.vistaMensajes.Groups[tema] != null;
    }

    ListViewGroup crearGrupo( string tema ) {
      return new ListViewGroup( tema, tema );
    }

    void incluirMensaje( Mensaje mensaje ) {
      ListViewItem item = crearItem( mensaje );
      item.Tag = mensaje;
      this.vistaMensajes.Groups[mensaje.Tema].Items.Add( item );
    }

    void incluirTema( string tema ) {
      this.vistaMensajes.Groups.Add( crearGrupo( tema ) );
    }

    void configurarVistaMensajes() {
      // configuración ListView
      this.vistaMensajes.Dock = DockStyle.Fill;
      this.vistaMensajes.View = View.LargeIcon;
      this.vistaMensajes.ShowGroups = true;
      this.vistaMensajes.ShowItemToolTips = true;
      this.vistaMensajes.Activation = ItemActivation.TwoClick;
      this.vistaMensajes.MultiSelect = false;
      this.vistaMensajes.HotTracking = false;
      this.vistaMensajes.HoverSelection = false;
      this.vistaMensajes.HideSelection = false;
      // manejador de evento SelectedIndexChanged
      this.vistaMensajes.SelectedIndexChanged += seleccionMensaje;
    }

    void notificarAtencionMensaje() {
      if ( this.MensajeAtendido != null ) {
        MensajeAtendido( this, null );
      }
    }

  }  //------- Fin clase VistaCarteleraWf

}  //------- Fin ES.EsquemaWf.VistaCarteleraWf.cs
