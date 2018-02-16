using System.Reflection;

namespace Ekia.EsquemaBasico.Tipos {
  /*---------------------------------------
      I n t e r f a z   P r o p i e d a d    
    ---------------------------------------*/

  public interface IAdaptadorPtyInf {
    string Nombre { get; }
    string Tipo { get; }
    string TipoBase { get; }
    bool PuedeLeer { get; }
    bool PuedeEscribir { get; }
    bool EsLista { get; }
    bool EsModelo { get; }
    object Valor { get; set; }
    IListaPropiedades Propiedades { get; }
    bool Implementa( string interfaz );
    PropertyInfo Origen();
  }

}	//------- Fin ES.Tipos.Reflexion.IAdaptadorPtyInf.cs
