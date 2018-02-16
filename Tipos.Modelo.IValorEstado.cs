using System;
using System.Collections.Generic;

namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------------------------------------
     I n t e r f a z   p a r a   V a l o r e s   d e   P r o p i e d a d e s 
    -------------------------------------------------------------------------*/

  public interface IValorEstado {
    object Contenido { get; set; }
    string ComoCadena();
    int ComoEntero();
    double ComoDoble();
    decimal ComoDecimal();
    bool ComoBoolean();
    DateTime ComoTiempo();
    IList<object> ComoLista();
  }

}	//------- Fin ES.Tipos.Modelo.IValorEstado.cs

