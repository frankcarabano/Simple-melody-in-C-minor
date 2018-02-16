using System;
using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
  public partial class VistaSeleccionWf : Form {
    protected System.Collections.ICollection lista;
    object seleccion;

    public VistaSeleccionWf() {
      InitializeComponent();
      this.Shown += new EventHandler( VistaMostrada );
      this.WidgetLista.SelectedIndexChanged += new EventHandler( SeleccionLista );
      this.botonCancelar.Click += new EventHandler( CancelarBusqueda );
    }

    public System.Collections.ICollection Lista {
      set { this.lista = value; }
    }

    public object Seleccion {
      get { return this.seleccion; }
    }

    protected virtual void mostrarLista() { }

    void SeleccionLista( object sender, EventArgs e ) {
      if ( ( sender as System.Windows.Forms.ListView ).SelectedItems.Count > 0 ) {
        object seleccion = (object)( sender as System.Windows.Forms.ListView ).SelectedItems[0].Tag;
        this.seleccion = seleccion;
      }
    }

    void CancelarBusqueda( object sender, EventArgs args ) {
      this.seleccion = null;
    }

    void VistaMostrada( object sender, EventArgs e ) {
      this.seleccion = default( object );
      mostrarLista();
    }

  }	//-------- Fin Clase VistaSeleccionWf

}	//------- Fin ES.EsquemaWf.VistaSeleccionWf.cs