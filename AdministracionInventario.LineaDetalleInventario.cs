using Ekia.AplicacionesNegocios.Comercializables;
using Ekia.AplicacionesNegocios.TransaccionesComercializables;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;
using Ekia.Persistencia.Tools;

namespace Ekia.AplicacionesNegocios.AdministracionInventario {
  /* ---------------------------------------------
         C L A S E   P A R A   L I N E A   D E    
      D E T A L L E   D E   T R A N S A C C I O N 
     ---------------------------------------------*/

  public class LineaDetalleInventario : ILineaDetalleInventario {
    readonly string oid;
    string codigoProducto;
    IBienComercializable item;
    decimal cantidad;

    public LineaDetalleInventario() {
      oid = crearOId();
      codigoProducto = string.Empty;
      item = null;
      cantidad = 0;
    }

    public LineaDetalleInventario( IBienComercializable itm, decimal cant ) : this() {
      codigoProducto = item.Codigo;
      item = itm;
      cantidad = cant;
    }

    public LineaDetalleInventario( string id, IBienComercializable itm, decimal cant ) {
      oid = id;
      codigoProducto = item.Codigo;
      item = itm;
      cantidad = cant;
    }

    public string OId {
      get { return oid; }
    }

    [ModelProperty( false )]
    public string Codigo {
      get { return codigoProducto; }
      set { codigoProducto = value; }
    }

    public string Descripcion {
      get { return item != null ? item.Descripcion : string.Empty; }
    }

    [ModelProperty( false )]
    public decimal Cantidad {
      get { return cantidad; }
      set { cantidad = value; }
    }

    public IBienComercializable Item {
      get { return item; }
    }

    public void EstablecerItem( IBienComercializable producto ) {
      item = producto;
      codigoProducto = item.Codigo;
    }

    public bool ItemEsNulo() {
      return item == null;
    }

    string crearOId() {
      return HiLowIdGeneratorClient.GetId();
    }

  }	//------- Fin clase LineaDetalleInventario

}	//------- Fin ES.AdministracionInventario.LineaDetalleInventario.cs