
namespace Ekia.EsquemaBasico.Tipos {
  /*----------------------------------------------
      I n t e r f a z   p a r a   L i s t a s 
     g e n é r i c a s   e s t i l o   A r r a y 
   -----------------------------------------------*/

  public interface IListaArreglo<TInstancia> : ILista {
    TInstancia this[int indice] { get; }
    IIteradorLista<TInstancia> Iterador { get; }
    void IncluirInstancia( TInstancia elemento );
    bool ContieneInstancia( TInstancia elemento );
  }

}	//------- Fin ES.Tipos.Listas.IListaArreglo.cs
