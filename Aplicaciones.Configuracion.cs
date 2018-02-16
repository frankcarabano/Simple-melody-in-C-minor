using System;

namespace Ekia.EsquemaBasico.Aplicaciones {
  /* -----------------------------------------------------------
      C L A S E   B A S E   P A R A   C O N F I G U R A C I O N 
                    D E   A P L I C A C I O N E S               
     -----------------------------------------------------------*/

  public abstract class Configuracion : IConfiguracion {
    protected string rutaConfiguracion;
    protected string rutaDatos;
    protected string rutaMapas;
    protected string rutaRepositorios;

    public Configuracion() {
      this.rutaConfiguracion = Environment.CurrentDirectory + @"\Configuracion";
      this.rutaDatos = Environment.CurrentDirectory + @"\Data";
      this.rutaMapas = Environment.CurrentDirectory + @"\Mapas";
      this.rutaRepositorios = Environment.CurrentDirectory + @"\Repositorios";
    }

    public Configuracion( string rutaDatos, string rutaConfiguracion, string rutaMapas, string rutaRepositorios ) {
      this.rutaConfiguracion = rutaConfiguracion;
      this.rutaDatos = rutaDatos;
      this.rutaMapas = rutaMapas;
      this.rutaRepositorios = rutaRepositorios;
    }

    public string RutaConfiguracion {
      get { return this.rutaConfiguracion; }
      set { this.rutaConfiguracion = value; }
    }

    public string RutaDatos {
      get { return this.rutaDatos; }
      set { this.rutaDatos = value; }
    }

    public string RutaMapas {
      get { return this.rutaMapas; }
      set { this.rutaMapas = value; }
    }

    public string RutaRepositorios {
      get { return this.rutaRepositorios; }
      set { this.rutaRepositorios = value; }
    }

    public abstract void Guardar();
    public abstract void Recuperar();
    public abstract void EstablecerBasica();

  }	//------- Fin clase Configuracion

}	//------- Fin ES.Aplicaciones.Configuracion.cs