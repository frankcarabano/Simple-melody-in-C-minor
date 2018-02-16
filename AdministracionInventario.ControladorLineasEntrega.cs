using Ekia.AplicacionesNegocios.Comercializables;
using Ekia.AplicacionesNegocios.TransaccionesComercializables;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.AplicacionesNegocios.AdministracionInventario {
  /* ---------------------------------------------------------------
      C O N T R O L A D O R   P A R A   L I N E A S - D E T A L L E 
          D E   T R A N S A C C I O N E S   D E   E N T R E G A     
     ---------------------------------------------------------------*/

  public abstract class ControladorLineasEntrega : ControladorLineasInventario {
    const string SIN_DISPONIBILIDAD = "No hay existencia disponible para la entrega de ";

    public ControladorLineasEntrega( IControladorMV controladorMV,
                                     IAdaptadorVista<ILineaDetalleInventario> vista ) : base( controladorMV, vista ) {
    }

    protected override void actualizarLista() {
      if ( !hayDisponibilidad( ( this.bufferInstancias as ILineaDetalleInventario ).Item, this.bufferInstancias.Cantidad ) ) {
        this.vista.Informar( SIN_DISPONIBILIDAD + ( this.bufferInstancias.Descripcion ) );
      }
      else {
        if ( this.esNuevaInstancia ) {
          incluirLinea();
        }
        else {
          actualizarLinea();
        }
        notificarActualizacion();
        crearNuevaInstancia();
      }
    }

    protected abstract bool hayDisponibilidad( IBienComercializable item, decimal cantidad );

    void incluirLinea() {
      try {
        this.lista.IncluirInstancia( this.bufferInstancias );
      }
      catch ( ClaveDuplicada e ) {
        procesarDuplicada();
      }
    }

    void actualizarLinea() {
      if ( claveEditada() ) {
        if ( this.lista.ContieneClave( this.bufferInstancias.Codigo ) ) {
          procesarDuplicada();
        }
        else {
          actualizarClave();
        }
      }
      else {
        actualizarInstancia();
      }
    }

  }	//------- Fin clase ControladorLineasEntrega

}	//------- Fin ES.AdministracionInventario.Controladores.cs