using System;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Mvc;

namespace Ekia.EsquemaWinForms {
  /* -----------------------------------------------------------
      C O N T R O L A D O R   M O D E L O - V I S T A   P A R A 
                 P L A T A F O R M A   W I N F O R M S           
     -----------------------------------------------------------*/

  public abstract class ControladorMvWf : ControladorMV {
    protected CadenaExtraccion cadenaExtraccion;

    //---------------------------------------//
    //       C o n s t r u c t o r e s       //
    //---------------------------------------//

    public ControladorMvWf() : base() {
      inicializar();
    }

    public ControladorMvWf( object mdlo ) : base( mdlo ) {
      inicializar();
    }

    public MapaMV MapaModeloVista {
      get { return this.mapaModeloVista; }
    }

    public IModelo Modelo {
      get { return this.modelo; }
    }

    public void RegistrarControl( System.Windows.Forms.Control control, string propiedad ) {
      this.mapaModeloVista.Mapear( control.Name, propiedad );
      this.cadenaExtraccion.Agregar( FabricaExtractores.Crear( control ) );
      establecerManejadorWidget( control );
    }


    //-------------------------------------------------//
    //    M é t o d o s   s o b r e s c r i t o s		//
    //-------------------------------------------------//

    protected override void extraerValorWidget( object widget, string propiedad, IValorEstado valor ) {
      System.Windows.Forms.Control control = (System.Windows.Forms.Control)widget;
      IAdaptadorPtyInf infoPropiedad = this.modelo.Reflexion.Propiedad( propiedad );
      this.cadenaExtraccion.ExtraerValorControl( control, infoPropiedad, valor );
    }

    protected override string nombrePropiedad( object widget ) {
      return this.mapaModeloVista[( widget as System.Windows.Forms.Control ).Name];
    }


    //----------------------------------------//
    //    M é t o d o s   p r i v a d o s		//
    //----------------------------------------//

    private void inicializar() {
      this.cadenaExtraccion = new CadenaExtraccion();
    }

    private void establecerManejadorWidget( System.Windows.Forms.Control control ) {
      if ( control is TextBoxBase ) {
        ( control as TextBoxBase ).TextChanged += new EventHandler( ActualizarModelo );
      }
      else if ( control is NumericUpDown ) {
        ( control as NumericUpDown ).ValueChanged += new EventHandler( ActualizarModelo );
      }
      else if ( control is DateTimePicker ) {
        ( control as DateTimePicker ).ValueChanged += new EventHandler( ActualizarModelo );
      }
      else if ( control is CheckBox ) {
        ( control as CheckBox ).CheckedChanged += new EventHandler( ActualizarModelo );
      }
      else if ( control is ComboBox ) {
        ( control as ComboBox ).SelectedIndexChanged += new EventHandler( ActualizarModelo );
      }
      else if ( control is ListBox ) {
        ( control as ListBox ).SelectedIndexChanged += new EventHandler( ActualizarModelo );
      }
      if ( !( ( control is ListView ) || ( control is TreeView ) ) ) {
        control.Leave += new EventHandler( ActualizarModelo );
      }
    }

  }	//------- Fin Clase ControladorMvWf

}	//------- Fin ES.ControladorMvWf.cs