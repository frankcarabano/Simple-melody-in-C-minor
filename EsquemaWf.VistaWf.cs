using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Mvc;

namespace Ekia.EsquemaWinForms {
  /*-------------------------------------------------------------------
              C l a s e   V i s t a   c ó s m i c a   p a r a          
                s o p o r t e   d e   E s q u e m a   M V C            
      ( b a s a d a   e n   S y s t e m . W i n d o w s . F o r m s )  
    -------------------------------------------------------------------*/

  public partial class VistaWf : Form, IVista {
    //------- C a m p o s   p r o t e g i d o s -------//
    protected bool estadoEditado;
    protected delegate void ProcesarInteraccion( object sender );
    protected ControladorMvWf ctrlMv;
    protected object modelo;
    protected IList<System.Windows.Forms.Control> contenedoresEdicion;
    readonly bool confirmacionSalida;


    //----------------------------------//
    //		C o n s t r u c t o r e s		//
    //----------------------------------//

    // Este constructor es necesario para tener habilitado el diseñador visual

    public VistaWf() {
      InitializeComponent();
      this.contenedoresEdicion = new List<System.Windows.Forms.Control>();
      this.confirmacionSalida = false;
    }

    public VistaWf( ControladorMvWf ctrl, bool confirmacionSalida ) : this() {
      this.confirmacionSalida = confirmacionSalida;
      this.modelo = null;
      this.ctrlMv = ctrl;
      this.ctrlMv.EstablecerVista( this );
    }

    public VistaWf( ControladorMvWf ctrl, bool confirmacionSalida, object mdlo ) : this( ctrl, confirmacionSalida ) {
      this.modelo = mdlo;
    }


    //-------------------------------//
    //		P r o p i e d a d e s		//
    //-------------------------------//

    public bool EstadoEditado {
      get { return this.estadoEditado; }
    }

    public bool ConfirmacionSalida {
      get { return this.confirmacionSalida; }
    }


    //----------------------------------------//
    //		M é t o d o s   p ú b l i c o s		//
    //----------------------------------------//

    public virtual void EstablecerModelo( object mdlo ) {
      this.modelo = mdlo;
    }

    public void ReflejarModelo() {
      reflejarCajasTexto();
      reflejarModelo();
      this.estadoEditado = false;
    }

    // Mostrar advertencia sobre alguna excepción capturada

    public void Advertir( string mensaje ) {
      MessageBox.Show( mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning );
    }

    // Mostrar un mensaje informativo

    public void Informar( string mensaje ) {
      MessageBox.Show( mensaje, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information );
    }

    // Verificar la intención antes de realizar una acción

    public bool ConfirmarIntencion( string accion, string mensaje ) {
      bool respuesta = false;
      string titulo = "Verificar " + accion;
      respuesta = ( MessageBox.Show( mensaje,
                                 titulo,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question ) == DialogResult.Yes );
      return respuesta;
    }

    // Habilitar edición del Modelo

    public virtual void Editar( bool limpiar ) {
      this.estadoEditado = false;
      if ( limpiar ) {
        limpiarControlesEdicion();
      }
      focoEnPrimerControl( this.contenedoresEdicion[0] );
    }

    // Indicar resultado de examen de regla de validación

    public virtual void IndicarResultadoValidacion( object widget, System.ApplicationException e ) {
      string mensaje = ( e != null ? ( e as ValorInvalido ).TextoIncumplimientos : string.Empty );
      this.Incumplimiento.SetError( widget as System.Windows.Forms.Control, mensaje );
    }


    //---------------------------------------------------------//
    //       M a n e j a d o r e s   d e   e v e n t o s       //
    //---------------------------------------------------------//

    // Al intentar cerrar

    protected virtual void IntentoCierre( object sender, FormClosingEventArgs e ) {
      if ( this.confirmacionSalida ) {
        if ( errorEdicion() ) {
          e.Cancel = !ConfirmarIntencion( "Salida", "Aún no han sido corregidos todos los errores. ¿Seguro desea salir?" );
        }
        else if ( this.ctrlMv != null ) {
          if ( this.ctrlMv.EstadoModeloEditado ) {
            e.Cancel = !ConfirmarIntencion( "Salida", "De continuar se perderán los cambios realizados. ¿Seguro desea salir?" );
          }
        }
      }
    }

    // Edición en cajas de texto

    protected virtual void EdicionCajaTexto( object sender, EventArgs args ) {
      this.estadoEditado = ( sender as System.Windows.Forms.TextBoxBase ).Text.Trim().Length > 0;
    }


    //-------------------------------------------------//
    //       M é t o d o s   p r o t e g i d o s       //
    //-------------------------------------------------//

    // Limpiar controles de edición del modelo

    protected void limpiarControlesEdicion() {
      limpiarControles();
    }

    // Limpiar controles de edición del modelo, comenzando por las cajas de texto en el contenedor de edición

    protected virtual void limpiarControles() {
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        limpiarCajasTextoContenedor( contenedor );
      }
    }

    // Establecer foco en primer control de contenedor de edición

    protected void focoEnPrimerControl( System.Windows.Forms.Control contenedor ) {
      if ( contenedor.Tag != null ) {
        System.Windows.Forms.Control control = (System.Windows.Forms.Control)contenedor.Tag;
        control.Focus();
      }
    }

    // Establecer estado como editado

    protected void establecerEstadoEditado() {
      this.estadoEditado = true;
    }

    // Establecer manejadores para monitoreo de estado editado en controles de edición

    protected virtual void monitoreoControlesEdicion() {
      monitoreoCajasTexto();
    }


    //---------------------------------------------//
    //       M é t o d o s   p r i v a d o s       //
    //---------------------------------------------//

    void reflejarCajasTexto() {
      // reflejar contenido de cajas de texto
      if ( this.ctrlMv != null ) {
        foreach ( string w in this.ctrlMv.MapaModeloVista.Widgets ) {
          int indice = 0;
          Control control = null;
          while ( control == null ) {
            control = this.contenedoresEdicion[indice].Controls[w];
            indice++;
          }
          if ( ( control is System.Windows.Forms.TextBoxBase ) && ( ( control.Tag != null ) && ( (string)control.Tag == "M" ) ) ) {
            IAdaptadorPtyInf propiedadMapeada = this.ctrlMv.Modelo.Reflexion.Propiedad( this.ctrlMv.MapaModeloVista[w] );
            if ( ( control as System.Windows.Forms.TextBoxBase ).Text != propiedadMapeada.Valor.ToString() ) {
              ( control as System.Windows.Forms.TextBoxBase ).Text = propiedadMapeada.Valor.ToString();
            }
          }
        }
      }
    }

    // Limpiar cajas de texto de un contenedor

    void limpiarCajasTextoContenedor( System.Windows.Forms.Control contenedor ) {
      foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
        // si el control es a su vez un contenedor limpiar sus cajas de texto
        if ( ctrl.Controls.Count > 0 ) {
          limpiarCajasTextoContenedor( ctrl );
        }
        else if ( ctrl is System.Windows.Forms.TextBoxBase ) {
          ctrl.Text = string.Empty;
        }
      }
    }

    // Determinar si hay error en un control de edición

    bool errorEdicion() {
      bool hayError = false;
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
          if ( this.Incumplimiento.GetError( ctrl ).Length > 0 ) {
            hayError = true;
            break;
          }
        }
        if ( hayError ) break;
      }
      return hayError;
    }

    // Establecer manejador interno de evento TextChanged para controles TextBoxBase

    void monitoreoCajasTexto() {
      foreach ( System.Windows.Forms.Control contenedor in this.contenedoresEdicion ) {
        foreach ( System.Windows.Forms.Control ctrl in contenedor.Controls ) {
          if ( ( ctrl is System.Windows.Forms.TextBoxBase ) && ( ( ctrl.Tag != null ) && ( (string)ctrl.Tag == "M" ) ) ) {
            ctrl.TextChanged += new EventHandler( EdicionCajaTexto );
          }
        }
      }
    }


    //----------------------------------------------------------------------//
    //					M é t o d o s   v i r t u a l e s   p o r						//
    //		i m p l e m e n t a r   e n   c l a s e s   d e r i v a d a s		//
    //----------------------------------------------------------------------//

    /* E s t a b l e c e r   m a n e j a d o r e s   p a r a   e v e n t o s   p r o g r a m a d o s
         e n   e l   c o n t r o l a d o r,   e   i n t e r a c c i o n e s   e n t r e   c o n t r o l e s
         ( p a t r ó n   M e d i a t o r )    */
    protected virtual void establecerManejadores() { }
    /* E s t a b l e c e r   m a p a s   d e   i n t e r a c c i o n e s   e n t r e   c o n t r o l e s
           ( p a t r ó n   M e d i a t o r )   */
    protected virtual void mapearInteracciones() { }
    // M a n e j a r   i n t e r a c c i o n e s   ( p a t r ó n   M e d i a t o r )
    protected virtual void manejarInteraccion( object sender, EventArgs e ) { }
    // E s t a b l e c e r   m a p a s   d e   p r o p i e d a d e s   d e l   M o d e l o
    protected virtual void mapearModelo() { }
    // R e f l e j a r   e l   M o d e l o
    protected virtual void reflejarModelo() { }
    /* I n d i z a r   b o t o n e s   d e   a c c i ó n   p a r a   c o r r e s p o n d e r
       c o n   c o m a n d o s	  d e l   c o n t r o l a d o r   */
    protected virtual void indizarBotonesAccion() { }
    protected virtual void indizarBotonesAccion( int tag ) {
    }

  }	//------- Fin Clase VistaWf

}	//------- Fin ES.EsquemaWf.VistaWf.cs