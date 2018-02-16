
namespace Ekia.EsquemaBasico.Reflexion {
  /*--------------------------------
     C l a s e   R e f l e c t o r 
    --------------------------------*/

  public static class Reflector {
    public static object ObtenerValorPropiedad( object instancia, string nombrePropiedad ) {
      return instancia.GetType().GetProperty( nombrePropiedad ).GetValue( instancia, null );
    }

    public static void EstablecerValorPropiedad( object instancia, string nombrePropiedad, object valor ) {
      instancia.GetType().GetProperty( nombrePropiedad ).SetValue( instancia, valor, null );
    }

  }	//------- Fin Clase Reflector

}	//------- Fin ES.Reflexion.Reflector.cs