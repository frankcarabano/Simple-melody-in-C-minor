
namespace Ekia.EsquemaBasico.Aplicaciones {
  /* --------------------------------------------------------------------------------------
      I N T E R F A Z  P A R A   C O N F I G U R A C I O N   D E   A P L I C A C I O N E S 
     --------------------------------------------------------------------------------------*/

  public interface IConfiguracion {
    string RutaConfiguracion { get; set; }
    string RutaDatos { get; set; }
    string RutaMapas { get; set; }
    string RutaRepositorios { get; set; }
    void Guardar();
    void Recuperar();
    void EstablecerBasica();
  }

}	//------- Fin ES.Aplicaciones.Interfaces.IConfiguracion.cs