using System.Collections;

namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------
     I n t e r f a z   R e f l e x i o n 
    -------------------------------------*/

  public interface IReflexion {
    ICollection Propiedades { get; }
    ICollection Nombres { get; }
    object Origen();
    IAdaptadorPtyInf Propiedad( string nombre );
  }

}	//------- Fin ES.Tipos.Reflexion.IReflexion.cs
