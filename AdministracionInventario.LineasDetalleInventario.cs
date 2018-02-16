using Ekia.AplicacionesNegocios.TransaccionesComercializables;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;
using Ekia.Persistencia.Tools;

namespace Ekia.AplicacionesNegocios.AdministracionInventario {
  /* -----------------------------------------------------------------------------
             C L A S E   P A R A   L I N E A S - D E T A L L E   D E   U N        
      D O C U M E N T O   D E   T R A N S A C C I O N   D E   I N V E N T A R I O 
     -----------------------------------------------------------------------------*/

  public class LineasDetalleInventario : PropiedadLista<ILineaDetalleInventario>, IOid {
    readonly string oid;

    internal LineasDetalleInventario() : base( "Codigo" ) {
      oid = crearOId();
    }

    public string OId {
      get { return oid; }
    }

    public override bool EliminarInstancia( string codigoProducto ) {
      return lista.Remove( codigoProducto );
    }

    protected override void manejarDuplicado( ILineaDetalleInventario linea ) {
      lista[linea.Codigo].Cantidad = linea.Cantidad;
    }

    string crearOId() {
      return HiLowIdGeneratorClient.GetId();
    }

  }	//------- Fin clase LineasDetalleInventario

}	//------- Fin ES.AdministracionInventario.LineasDetalleInventario.cs