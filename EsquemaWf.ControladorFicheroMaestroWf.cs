using System.Collections.Generic;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.EsquemaWinForms {
  /*--------------------------------------------------------------
      C l a s e    b a s e   p a r a   C o n t r o l a d o r e s
         d e   F i c h e r o s   M a e s t r o s   b a s a d a    
              e n   S y s t e m . W i n d o w s . F o r m s
    --------------------------------------------------------------*/

  public abstract class ControladorFicheroMaestroWf<TElemento> : ControladorFicheroMaestro<TElemento> {
    //-----------------------------------//
    //       C o n s t r u c t o r       //
    //-----------------------------------//

    public ControladorFicheroMaestroWf( IFicheroMaestro<TElemento> list,
                                        string nmbElm,
                                        IControladorMV ctrlMV,
                                        IVistaFicheroMaestro vist ) : base( list, nmbElm, ctrlMV, vist ) {
      ( this.vista as VistaFicheroMaestroWf ).ManejadorBarraHerramientas = ComandoSeleccionado;
    }

    //---------------------------------------------------//
    //    M a n e j a d o r e s   d e   e v e n t o s    //
    //---------------------------------------------------//

    // Maneja la selección de comandos a través de los botones de la barra de herramientas 

    public void ComandoSeleccionado( object sender, ToolStripItemClickedEventArgs e ) {
      if ( e.ClickedItem is ToolStripButton ) {
        IList<ToolStripButton> botones = (IList<ToolStripButton>)( sender as ToolStrip ).Tag;
        int indice = botones.IndexOf( e.ClickedItem as ToolStripButton );
        this.comandos[indice].Ejecutar();
      }
    }

  }	//------- Fin clase ControladorFicheroMaestroWf<TElemento>

}	//------- Fin ES.EsquemaWf.ControladorFicheroMaestroWf.cs