using System.Collections.Generic;

namespace Ekia.EsquemaBasico.Tipos {
  /*---------------------------------------------
      I n t e r f a z   p a r a   L i s t a s   
     e s t i l o   a r c h i v o   m a e s t r o 
   ----------------------------------------------*/

  public interface IFicheroMaestro<TInstancia> : IListaGenerica<TInstancia> {
    IList<TInstancia> Lista { get; }
    TInstancia CrearInstancia();
    TInstancia InstanciaPorOId( string oid );
    TInstancia InstanciaPorClave( string clave );
    IFicheroMaestro<TInstancia> Recuperar();
    IEnumerable<TInstancia> Instancias();
    void GuardarInstancia( TInstancia instancia );
    void ActivarInstancia( TInstancia instancia );
    void DesactivarInstancia( TInstancia instancia );
    void EliminarInstancia( TInstancia instancia );
    void Indizar();
  }

}	//------- Fin ES.Tipos.Listas.IFicheroMaestro.cs
