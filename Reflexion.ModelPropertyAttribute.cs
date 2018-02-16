
namespace Ekia.EsquemaBasico.Reflexion {
  /*-----------------------------------------------------------------------------------------------------
     C L A S E   A T R I B U T O   M O D E L O   Q U E   I N D I C A   Q U E   U N A   P R O P I E D A D 
               D E B E   S E R   T R A T A D A   C O M O   P A R T E   D E   U N   M O D E L O           
    -----------------------------------------------------------------------------------------------------*/

  public class ModelPropertyAttribute : System.Attribute {
    bool esModelo;

    public ModelPropertyAttribute( bool esModelo ) : base() {
      this.esModelo = esModelo;
    }

    public bool EsModelo {
      get { return this.esModelo; }
    }

  }	//------- Fin clase ModelPropertyAttribute

}	//------- Fin ES.Reflexion.ModelProperty.cs