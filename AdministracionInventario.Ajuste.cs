using System;

namespace Ekia.AplicacionesNegocios.AdministracionInventario {
  /* ---------------------------------------------------------------
      C L A S E   P A R A   A J U S T E   D E   I N V E N T A R I O 
     ---------------------------------------------------------------*/

  public abstract class Ajuste : TransaccionInventario {
    public Ajuste( int proximoAjuste ) : base( proximoAjuste ) {
    }

    public Ajuste( int proximoAjuste, TransaccionInventario origen ) : base( proximoAjuste, origen ) {
    }

    public Ajuste( string oid, DateTime registro, string numeroDocumento, string observaciones ) :
             base( oid, registro, numeroDocumento, observaciones ) {
    }

  }	//------- Fin clase Ajuste

}	//------- Fin ES.AdministracionInventario.Ajuste.cs