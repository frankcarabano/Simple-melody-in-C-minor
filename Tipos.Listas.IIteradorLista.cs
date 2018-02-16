
namespace Ekia.EsquemaBasico.Tipos {
  /*---------------------------------------------
     I n t e r f a z   p a r a   i t e r a d o r 
         d e   l i s t a s   g e n é r i c a s    
    ---------------------------------------------*/

  public interface IIteradorLista<TElemento> {
    int Conteo { get; }
    TElemento Actual { get; }
    void Iniciar();
    bool Iterar();
  }

}	//------- Fin ES.Tipos.Listas.IIteradorLista.cs
