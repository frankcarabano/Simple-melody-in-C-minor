
namespace Ekia.EsquemaBasico.Aplicaciones {
  /* -------------------------------------------------
      C L A S E   B A S E   P A R A   U S U A R I O S 
     -------------------------------------------------*/

  public class Usuario {
    protected string nombre;
    protected string clave;

    public Usuario() {
      this.nombre = string.Empty;
      this.clave = string.Empty;
    }

    public Usuario( string nombre, string clave ) {
      this.nombre = nombre;
      this.clave = clave;
    }

    public override string ToString() {
      return nombre;
    }

  }	//------- Fin clase Usuario

}	//------- Fin ES.Aplicaciones.Usuario.cs
