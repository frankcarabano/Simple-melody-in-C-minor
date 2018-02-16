using System.Collections.Generic;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Listas;

namespace Ekia.EsquemaWinForms {
  /* -----------------------------------------------------------------------------
      A D A P T A D O R   D E   I N T E R F A Z   I L I S T A I N C R U S T A D A 
          P A R A   S Y S T E M . W I N D O W S . F O R M S . L I S T V I E W      
     -------------------------------------------------------------------------------*/

  public abstract class AdaptadorListView<TInstancia> : IPropiedadLista<TInstancia> {
    protected System.Windows.Forms.ListView listView;
    protected string nombreClave;

    //-----------------------------------//
    //       C o n s t r u c t o r       //
    //-----------------------------------//

    public AdaptadorListView( System.Windows.Forms.ListView listView, string nombreClave ) {
      this.listView = listView;
      this.nombreClave = nombreClave;
    }

    //-----------------------------------//
    //       P r o p i e d a d e s      //
    //-----------------------------------//

    public int Conteo {
      get { return this.listView.Items.Count; }
    }

    public bool EstaVacante {
      get { return this.listView.Items.Count == 0; }
    }

    public TInstancia this[string clave] {
      get {
        TInstancia instancia = default( TInstancia );
        ListViewItem lvi = buscarInstancia( clave );
        if ( lvi != null ) {
          if ( lvi.Tag != null ) {
            instancia = (TInstancia)lvi.Tag;
          }
        }
        return instancia;
      }
    }

    public IIteradorLista<TInstancia> Iterador {
      get {
        IList<TInstancia> lista = new List<TInstancia>();
        foreach ( ListViewItem lvi in this.listView.Items ) {
          if ( lvi.Tag != null ) {
            lista.Add( (TInstancia)lvi.Tag );
          }
        }
        return new IteradorLista<TInstancia>( lista );
      }
    }

    public string NombreClave {
      get { return this.nombreClave; }
    }

    //----------------------------------------//
    //    M é t o d o s   p ú b l i c o s		  //
    //----------------------------------------//

    public void Limpiar() {
      this.listView.Items.Clear();
    }

    public void IncluirInstancia( object instancia ) {
      if ( instancia is TInstancia ) {
        incluirInstancia( (TInstancia)instancia );
      }
    }

    public void IncluirInstancia( TInstancia instancia ) {
      incluirInstancia( instancia );
    }

    public bool EliminarInstancia( string clave ) {
      ListViewItem buscada = buscarInstancia( clave );
      if ( buscada != null ) {
        this.listView.Items.Remove( buscada );
      }
      return !ContieneClave( clave );
    }

    public bool ContieneClave( string clave ) {
      return buscarInstancia( clave ) != null;
    }

    //--------------------------------------------//
    //    M é t o d o s   p r o t e g i d o s		  //
    //--------------------------------------------//

    protected abstract void incluirInstancia( TInstancia instancia );

    //----------------------------------------//
    //    M é t o d o s   p r i v a d o s		  //
    //----------------------------------------//

    ListViewItem buscarInstancia( string clave ) {
      ListViewItem buscada = null;
      buscada = this.listView.FindItemWithText( clave );
      return buscada;
    }

  }	//------- Fin Clase AdaptadorListView

}	//------- Fin ES.EsquemaWf.AdaptadorListView.cs