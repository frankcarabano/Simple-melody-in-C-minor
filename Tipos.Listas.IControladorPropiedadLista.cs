using System;

namespace Ekia.EsquemaBasico.Tipos {
  /*---------------------------------------------------
     I n t e r f a z   p a r a   C o n t r o l a d o r 
          d e   P r o p i e d a d e s - L i s t a         
    ---------------------------------------------------*/

  public interface IControladorPropiedadLista<TInstancia> {
    IIteradorLista<TInstancia> IteradorLista { get; }
    bool EsNuevaInstancia { get; }
    TInstancia InstanciaActual { get; }
    void EstablecerLista( IPropiedadLista<TInstancia> lista );
    void ActualizarLista( object sender, EventArgs args );
    void SeleccionarInstancia( string clave );
    void EliminarInstancia( object sender, EventArgs args );
  }

}	//------- Fin ES.Tipos.Listas.IControladorPropiedadLista.cs
