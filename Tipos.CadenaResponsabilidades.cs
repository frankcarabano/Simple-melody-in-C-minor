using System.Collections.Generic;

namespace Ekia.EsquemaBasico.Tipos {
  /*---------------------------------------------------------------
     I m p l e m e n t a c i ó n   b á s i c a   d e   P a t r ó n 
              C h a i n   o f   R e s p o n s i b i l i t y         
    -----------------------------------------------------------------*/

  // Cadena de Responsabilidades (Chain of Responsibility)

  public abstract class CadenaResponsabilidades {
    private IList<IEslabonResponsabilidad> responsabilidades;

    public CadenaResponsabilidades() {
      this.responsabilidades = new List<IEslabonResponsabilidad>();
    }

    public int Cuenta {
      get { return this.responsabilidades.Count; }
    }

    public void Agregar( IEslabonResponsabilidad eslabon ) {
      this.responsabilidades.Add( eslabon );
      int cuenta = this.responsabilidades.Count;
      if ( cuenta > 1 ) {
        this.responsabilidades[( cuenta - 2 )].Sucesor = this.responsabilidades[( cuenta - 1 )];
      }
    }

    protected IEslabonResponsabilidad obtenerEslabon( int indice ) {
      return this.responsabilidades[indice];
    }

  }

}	//------- Fin ES.Tipos.CadenaResponsabilidades.cs