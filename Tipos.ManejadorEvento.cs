
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------------
             C l a s e   b a s e   p a r a        
        M a n e j a d o r e s   d e   E v e n t o s 
    ------------------------------------------------*/

  public abstract class ManejadorEvento : IEslabonResponsabilidad {
    protected IEslabonResponsabilidad sucesor;
    public IEslabonResponsabilidad Sucesor {
      get { return sucesor; }
      set { sucesor = value; }
    }
    public abstract bool PuedeManejar( object mensaje );
    public abstract void Manejar( object mensaje );
  }

}	//------- Fin ES.Tipos.ManejadorEvento.cs