using System;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Mvc {
  /*-----------------------------------------------
     C L A S E   B A S E   P A R A   M O D E L O S 

       Implementa una adaptación del esquema de 
       Reglas de validación propuesto en el libro
       "Expert C# 2005 Business Objects"
       por Rockford Lhotka             
    -----------------------------------------------*/

  public abstract class AdaptadorModelo : IModelo {
    bool estadoEditado;
    bool estadoValido;
    IncumplimientosReglas incumplimientos;
    protected IReflexion reflexion;
    protected ReglasValidacion reglas;

    public AdaptadorModelo( object origen ) {
      this.reflexion = new AdaptadorReflexion( origen );
      this.reglas = new ReglasValidacion();
      this.incumplimientos = new IncumplimientosReglas();
      this.estadoEditado = false;
      this.estadoValido = false;
    }

    public bool EstadoValido {
      get { return this.estadoValido; }
    }

    public bool EstadoEditado {
      get { return this.estadoEditado; }
    }

    public IReflexion Reflexion {
      get { return this.reflexion; }
    }

    public void Actualizar( string propiedad, IValorEstado valor ) {
      if ( this.reflexion.Propiedad( propiedad ).Implementa( "IPropiedadLista" ) ) {
        actualizarPropiedadLista( propiedad, valor );
      }
      else {
        actualizarPropiedadAtomica( propiedad, valor );
      }
    }

    public void MarcarLimpio() {
      this.estadoEditado = false;
    }

    void actualizarPropiedadAtomica( string propiedad, IValorEstado valor ) {
      this.estadoValido = true;
      this.estadoEditado = false;
      if ( hayReglasQueValidar() ) {																	              // Si hay reglas que validar
        Incumplimientos incumplimientos = this.reglas.Validar( propiedad, valor );  //  validarlas
        if ( incumplimientos != null && incumplimientos.Conteo > 0 ) {					    //  si hubo incumplimientos
          invalidarEstado();        															                  //  establecer estado como no-válido
          agregarIncumplimientosPropiedad( propiedad, incumplimientos );			      //  agregar a Incumplimientos de Propiedad
          lanzarExcepcionValorInvalido( valor, incumplimientos );	                  //  lanzar excepción 
        }
        else {																						                          //  si no hubo incumplimientos
          this.incumplimientos.Eliminar( propiedad );										            //	 eliminar Propiedad de la lista
        }
      }
      if ( this.estadoValido ) {																		                // Si el estado es válido
        this.reflexion.Propiedad( propiedad ).Valor = valor.Contenido;					    //  actualizar Propiedad
        this.estadoEditado = true;																	                //  establecer estado como editado
      }
    }

    void actualizarPropiedadLista( string propiedad, IValorEstado valor ) {
      this.estadoValido = true;
      this.estadoEditado = false;
      if ( hayReglasQueValidar() ) {																	              // Si hay reglas que validar
        Incumplimientos incumplimientos = this.reglas.Validar( propiedad, valor );	//  validarlas
        if ( incumplimientos != null && incumplimientos.Conteo > 0 ) {              //  si hubo incumplimientos
          if ( incumplimientos.Conteo > 0 ) {
            invalidarEstado();        															                //  establecer estado como no-válido
            agregarIncumplimientosPropiedad( propiedad, incumplimientos );			    //  agregar a Incumplimientos de Propiedad
            lanzarExcepcionValorInvalido( valor, incumplimientos );                 //  lanzar excepción 
          }
          else {																						                        //  si no hubo incumplimientos
            this.incumplimientos.Eliminar( propiedad );										          //	 eliminar Propiedad de la lista
          }
        }
      }
      if ( this.estadoValido ) {
        actualizarLista( propiedad, valor );
        this.estadoEditado = true;																	                //  establecer estado como editado
      }
    }

    void actualizarLista( string propiedad, IValorEstado valor ) {
      IList<object> lista = valor.ComoLista();
      Type tipo = this.reflexion.Origen().GetType();
      ( this.reflexion.Propiedad( propiedad ).Valor as ILista ).Limpiar();
      foreach ( object obj in lista ) {
        ( this.reflexion.Propiedad( propiedad ).Valor as IListaIncrustada ).IncluirInstancia( obj );
      }
    }

    void invalidarEstado() {
      this.estadoValido = false;
    }

    void agregarIncumplimientosPropiedad( string propiedad, Incumplimientos incumplimientos ) {
      this.incumplimientos.Agregar( propiedad, incumplimientos );
    }

    void lanzarExcepcionValorInvalido( IValorEstado valor, Incumplimientos incumplimientos ) {
      throw new ValorInvalido( "Valor inválido", valor, incumplimientos );
    }
    bool hayReglasQueValidar() {
      return this.reglas.Conteo > 0;
    }

  }	//------- Fin Clase AdaptadorModelo

}	//------- Fin ES.Mvc.AdaptadorModelo.cs