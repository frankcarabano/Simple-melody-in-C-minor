using System;
using Ekia.AplicacionesNegocios.Comercializables;
using Ekia.AplicacionesNegocios.TransaccionesComercializables;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.AplicacionesNegocios.AdministracionInventario {
  /* ---------------------------------------------------------------
      C O N T R O L A D O R   P A R A   L I N E A S - D E T A L L E 
       D E   T R A N S A C C I O N E S   D E   I N V E N T A R I O  
     ---------------------------------------------------------------*/

  public abstract class ControladorLineasInventario : ControladorPropiedadLista<ILineaDetalleInventario> {
    protected TransaccionInventario transaccion;

    public ControladorLineasInventario( IControladorMV controladorMV,
                                        IAdaptadorVista<ILineaDetalleInventario> vista ) : base( controladorMV, vista ) {
      this.controladorMV.CambioEstadoModelo += new CambioEstadoModeloManejador( EdicionLinea );
    }

    public override void ActualizarLista( object sender, EventArgs args ) {
      actualizarLista();
    }

    public override void SeleccionarInstancia( string clave ) {
      base.SeleccionarInstancia( clave );
    }

    public override void EliminarInstancia( object sender, EventArgs args ) {
      base.EliminarInstancia( sender, args );
    }

    public virtual void EdicionLinea( object sender, CambioEstadoModeloEventArgs args ) {
      if ( args.PropiedadCambiada.Nombre == this.lista.NombreClave ) {
        bool buscar = false;
        if ( this.bufferInstancias.ItemEsNulo() ) {
          buscar = true;
        }
        else if ( claveEditada() ) {
          buscar = true;
        }
        if ( buscar ) {
          establecerItemLinea( buscarComercializable( (string)args.PropiedadCambiada.Valor ) );
        }
      }
    }

    public void EstablecerItemLinea( IBienComercializable item ) {
      establecerItemLinea( item );
    }

    public void EstablecerTransaccion( TransaccionInventario transaccion ) {
      this.transaccion = transaccion;
      EstablecerLista( this.transaccion.Lineas );
    }

    protected virtual void actualizarLista() {
      if ( this.esNuevaInstancia ) {															        // si es una nueva linea
        try {
          this.lista.IncluirInstancia( this.bufferInstancias );   		    // tratar de incluirla
        }
        catch ( ClaveDuplicada e ) {															        // de tratarse de una clave duplicada
          procesarDuplicada();																            // procesar la línea con clave duplicada
        }
      }
      else {																						                  // si ya existe la línea
        if ( claveEditada() ) {								                            // si la clave ha sido editada
          if ( this.lista.ContieneClave( this.claveInstanciaActual ) ) {  // si ya existe
            procesarDuplicada();															            // procesar la línea con clave duplicada
          }
          else {
            actualizarClave();															              // de no existir actualizar para la nueva clave
          }
        }
        else {
          actualizarInstancia();															            // de no haberse editado clave actualizar línea
        }
      }
      notificarActualizacion();
      crearNuevaInstancia();
    }

    protected virtual IBienComercializable buscarComercializable( string codigo ) {
      return null;
    }

    protected override ILineaDetalleInventario crearInstancia() {
      return new LineaDetalleInventario();
    }

    protected override void copiarInstanciaAlBuffer( string codigoProducto ) {
      this.bufferInstancias.Codigo = codigoProducto;
      this.bufferInstancias.EstablecerItem( this.lista[codigoProducto].Item );
      this.bufferInstancias.Cantidad = this.lista[codigoProducto].Cantidad;
    }

    protected override void actualizarInstancia() {
      this.lista[this.bufferInstancias.Codigo].Cantidad = this.bufferInstancias.Cantidad;
    }

    protected void procesarDuplicada() {
      actualizarInstancia();
    }

    void establecerItemLinea( IBienComercializable item ) {
      this.bufferInstancias.EstablecerItem( item );
    }

  }	//------- Fin clase ControladorLineasInventario

}	//------- Fin ES.AdministracionInventario.ControladorLineasInventario.cs