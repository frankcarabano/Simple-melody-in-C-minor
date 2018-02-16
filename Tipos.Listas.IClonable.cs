
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------
    I n t e r f a z   p a r a   C l o n a c i ó n 
                d e   e l e m e n t o s            
   -----------------------------------------------*/

  public interface IClonable<TInstancia> {
    TInstancia Clonar();
    TInstancia Duplicar();
  }

}	//------- Fin ES.Tipos.Listas.IClonable.cs
