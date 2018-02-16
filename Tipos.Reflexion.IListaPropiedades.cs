using System.Collections;

namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------------------
     I n t e r f a z   L i s t a   d e   P r o p i e d a d e s
    -----------------------------------------------------------*/

  public interface IListaPropiedades {
    IAdaptadorPtyInf this[string nombre] { get; }
    ICollection Lista { get; }
    string[] Nombres { get; }
    int Conteo { get; }
    void Agregar( IAdaptadorPtyInf propiedad );
  }

}	//------- Fin ES.Tipos.Reflexion.IListaPropiedades.cs
