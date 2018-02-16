
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------
     I n t e r f a z   p a r a   n a v e g a d o r 
        d e   A r c h i v o s   m a e s t r o s      
   ------------------------------------------------*/

  public interface INavegadorFicheroMaestro<TInstancia> {
    int Posicion { get; }
    TInstancia Instancia( int indice );
    TInstancia Actual();
    TInstancia Primera();
    TInstancia Anterior();
    TInstancia Siguiente();
    TInstancia Ultima();
  }

}	//------- Fin ES.Tipos.Listas.INavegadorFicheroMaestro.cs
