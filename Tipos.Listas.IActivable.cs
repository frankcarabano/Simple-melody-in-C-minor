
namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------------------------------
     I n t e r f a z   p a r a   e l e m e n t o s   d e   L i s t a s 
       q u e   t e n g a n   e s t a d o   d  e   a c t i v a c i ó n       
    --------------------------------------------------------------------*/

  public interface IActivable {
    bool EstaActivo { get; }
    void Activar();
    void Desactivar();
  }

}	//------- Fin ES.Tipos.Listas.IActivable.cs