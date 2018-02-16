
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------------------------
    I n t e r f a z   p a r a   L i s t a s   i n c r u s t a d a s 
   ------------------------------------------------------------------*/

  public interface IPropiedadLista<TElemento> : IListaGenerica<TElemento>, IListaIncrustada {
    bool EliminarInstancia( string clave );
  }

}	//------- Fin ES.Tipos.Listas.IPropiedadLista.cs
