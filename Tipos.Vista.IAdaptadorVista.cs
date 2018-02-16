
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------------------------------
      I n t e r f a z   p a r a   a d a p t a c i o n   d e   v i s t a s  
     b a s a d a s   e n   c o n t e n e d o r e s   i n c r u s t a d o s 
    -----------------------------------------------------------------------*/

  public interface IAdaptadorVista<TElemento> : IVista {
    void EstablecerControlLista( IControladorPropiedadLista<TElemento> controlador );
  }

}	// Fin ES.Tipos.Vista.IAdaptadorVista.cs