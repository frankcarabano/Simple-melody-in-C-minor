
namespace Ekia.EsquemaBasico.Tipos {
  /*-------------------------------------------------------------------
        I n t e r f a c e s   p a r a   i m p l e m e n t a c i ó n
     d e   P a t r ó n   C h a i n   o f   R e s p o n s i b i l i t y 
    -------------------------------------------------------------------*/

  // Interfaz para eslabon de la cadena

  public interface IEslabonResponsabilidad {
    IEslabonResponsabilidad Sucesor { get; set; }
    bool PuedeManejar( object mensaje );
    void Manejar( object mensaje );
  }

}	//------- Fin ES.Tipos.IEslabonResponsabilidad.cs