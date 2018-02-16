
namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------------------------
    I n t e r f a z   p a r a   L i s t a s   G e n é r i c a s 
   --------------------------------------------------------------*/

  public interface IListaGenerica<TInstancia> : ILista {
    TInstancia this[string clave] { get; }
    IIteradorLista<TInstancia> Iterador { get; }
    string NombreClave { get; }
    void IncluirInstancia( TInstancia instancia );
    bool ContieneClave( string clave );
  }

}	//------- Fin ES.Tipos.Listas.IListaGenerica.cs
