using System;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Mvc {
  /*-----------------------------------------------------------
     C l a s e   b a s e   p a r a   C o n t r o l a d o r e s    
                 e n   e l   E s q u e m a   M V C                         
    -----------------------------------------------------------*/

  public abstract class ControladorMV : IControladorMV {
    protected MapaMV mapaModeloVista;
    protected IModelo modelo;
    protected IVista vista;
    bool edicionActiva;
    public event CambioEstadoModeloManejador CambioEstadoModelo;

    public ControladorMV() {
      this.edicionActiva = true;
      this.mapaModeloVista = new MapaMV();
    }

    public ControladorMV( object mdlo ) : this() {
      if ( mdlo != null ) {
        this.modelo = crearModelo( mdlo );
      }
    }


    //-----------------------------//
    //    P r o p i e d a d e s    //
    //-----------------------------//

    public bool EdicionActiva {
      get { return this.edicionActiva; }
    }

    public bool EstadoModeloEditado {
      get {
        bool editado = false;
        if ( this.modelo != null ) {
          editado = this.modelo.EstadoEditado;
        }
        return editado;
      }
    }

    public bool EstadoModeloValido {
      get {
        bool valido = true;
        if ( this.modelo != null ) {
          valido = this.modelo.EstadoValido;
        }
        return valido;
      }
    }


    //---------------------//
    //    M é t o d o s    //
    //---------------------//

    public void EstablecerVista( IVista vist ) {
      this.vista = vist;
    }

    public virtual void EstablecerModelo( object mdlo ) {
      if ( mdlo != null ) {
        this.modelo = crearModelo( mdlo );
      }
    }

    public void LimpiarModelo() {
      this.modelo.MarcarLimpio();
    }

    public void ActivarEdicion() {
      this.edicionActiva = true;
    }

    public void DesactivarEdicion() {
      this.edicionActiva = false;
    }

    public virtual void ActualizarModelo( object widget, EventArgs args ) {
      if ( ( this.edicionActiva ) && ( this.vista.EstadoEditado ) ) {
        IValorEstado valor = new ValorEstado();
        string propiedad = nombrePropiedad( widget );
        extraerValorWidget( widget, propiedad, valor );
        try {
          this.modelo.Actualizar( propiedad, valor );
          NotificarActualizacion( this.modelo.Reflexion.Propiedad( propiedad ) );
          this.vista.IndicarResultadoValidacion( widget, null );
          this.vista.ReflejarModelo();
        }
        catch ( ValorInvalido e ) {
          this.vista.IndicarResultadoValidacion( widget, e );
        }
      }
    }

    public virtual void ActualizarModelo( string propiedad, IValorEstado valor, object widget ) {
      try {
        this.modelo.Actualizar( propiedad, valor );
        NotificarActualizacion( this.modelo.Reflexion.Propiedad( propiedad ) );
        if ( widget != null ) {
          this.vista.IndicarResultadoValidacion( widget, null );
        }
        this.vista.ReflejarModelo();
      }
      catch ( ValorInvalido e ) {
        if ( widget != null ) {
          this.vista.IndicarResultadoValidacion( widget, e );
        }
        else {
          this.vista.Informar( e.Message );
        }
      }
    }

    protected void NotificarActualizacion( IAdaptadorPtyInf propiedad ) {
      if ( this.CambioEstadoModelo != null ) {
        CambioEstadoModeloEventArgs arg = new CambioEstadoModeloEventArgs( propiedad,
                                                                              this.modelo.Reflexion.Origen() );
        CambioEstadoModelo( this, arg );
      }
    }

    protected abstract string nombrePropiedad( object widget );
    protected abstract void extraerValorWidget( object widget, string propiedad, IValorEstado valor );
    protected abstract IModelo crearModelo( object origen );

  }	//------- Fin Clase ControladorMv

}	//------- Fin ES.Mvc.ControladorMV.cs