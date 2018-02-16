
namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------------
           C l a s e   V i s t a   p a r a   C u a d r o s   d e       
                     d i á l o g o   g e n e r a l e s                 
      ( b a s a d a   e n   S y s t e m . W i n d o w s . F o r m s )  
    -------------------------------------------------------------------*/

  public partial class VistaDialogoGeneralWf : VistaWf {
    //----------------------------------//
    //		C o n s t r u c t o r e s		//
    //----------------------------------//

    // Este constructor es necesario para tener habilitado el diseñador visual

    public VistaDialogoGeneralWf() : base() {
      InitializeComponent();
    }

    public VistaDialogoGeneralWf( ControladorMvWf ctrl, bool confirmacionSalida ) : base( ctrl, confirmacionSalida ) {
      InitializeComponent();
    }

    public VistaDialogoGeneralWf( ControladorMvWf ctrl, bool confirmacionSalida, object mdlo ) : base( ctrl, confirmacionSalida, mdlo ) {
      InitializeComponent();
    }

  }	//------- Fin Clase VistaDialogoGeneralWf

}	//------- Fin ES.EsquemaWf.VistaDialogoGeneralWf.cs