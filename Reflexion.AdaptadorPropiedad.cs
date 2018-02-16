using System;
using System.Reflection;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Reflexion {
  /*-------------------------------------------------------------------------------
                             C l a s e   P r o p i e d a d                         
	                                                                                 
    mediante la interfaz IAdaptadorPtyInf esta clase implementa el patron Adapter
    (de objeto), adaptando la clase System.Reflection.PropertyInfo 
    ------------------------------------------------------------------------------*/

  public class AdaptadorPropiedad : IAdaptadorPtyInf {
    PropertyInfo info;
    object instancia;
    IListaPropiedades propiedades;                              // implementacion de patron Composite

    internal AdaptadorPropiedad( PropertyInfo propInfo, object instanc ) {
      this.info = propInfo;
      this.instancia = instanc;
      if ( ( tieneAtributos() ) && ( esParteModelo() ) ) {
        if ( esModelo() ) {
          this.propiedades = new ListaPropiedades();         // es un Modelo agregado
        }
        else {
          this.propiedades = null;									// es un valor atomico				
        }
      }
    }

    public string Nombre {
      get { return this.info.Name; }
    }

    public string Tipo {
      get { return this.info.PropertyType.Name; }
    }

    public string TipoBase {
      get { return this.info.PropertyType.BaseType.Name; }
    }

    public bool PuedeLeer {
      get { return this.info.CanRead; }
    }

    public bool PuedeEscribir {
      get { return this.info.CanWrite; }
    }

    public bool EsLista {
      get {
        return this.info.PropertyType.GetInterface( "IList" ) != null ||
               this.info.PropertyType.GetInterface( "IDictionary" ) != null;
      }
    }

    public bool EsModelo {
      get { return esModelo(); }
    }

    public object Valor {
      get { return this.info.GetValue( this.instancia, null ); }
      set {
        // código adaptado del Libro "C# 2005 Business Objects" por Robert Lhotka
        object valor = value;
        if ( valor == null ) {
          this.info.SetValue( this.instancia, valor, null );
        }
        else {
          if ( this.info.PropertyType.Name == valor.GetType().Name |
             interfazEnJerarquia( valor.GetType(), this.info.PropertyType.Name ) |
             esTipoDerivado( valor.GetType(), this.info.PropertyType.Name ) ) {
            this.info.SetValue( this.instancia, valor, null );
          }
        }
      }
    }

    public IListaPropiedades Propiedades {
      get { return this.propiedades; }
    }

    public bool Implementa( string interfaz ) {
      return this.info.PropertyType.Name.Contains( interfaz ) | interfazEnJerarquia( this.info.PropertyType, interfaz );
    }

    public PropertyInfo Origen() {
      return this.info;
    }

    bool tieneAtributos() {
      return this.info.GetCustomAttributes( true ).Length > 0;
    }

    bool esParteModelo() {
      return this.info.GetCustomAttributes( true )[0].GetType() == typeof( ModelPropertyAttribute );
    }

    bool esModelo() {
      return ( this.info.GetCustomAttributes( true )[0] as ModelPropertyAttribute ).EsModelo;
    }

    bool interfazEnJerarquia( Type tipoAnalizado, string interfaz ) {
      bool incluida = false;
      Type[] tipos = tipoAnalizado.GetInterfaces();
      foreach ( Type tipo in tipos ) {
        incluida = tipo.Name.Contains( interfaz );
        if ( incluida ) break;
      }
      return incluida;
    }

    bool esTipoDerivado( Type tipoHijo, string tipoPadre ) {
      bool deriva = false;
      if ( tipoHijo.Name != "Object" ) {
        if ( tipoHijo.BaseType.Name == tipoPadre ) {
          deriva = true;
        }
        else {
          Type tipo_hijo = tipoHijo.BaseType;
          deriva = esTipoDerivado( tipo_hijo, tipoPadre );
        }
      }
      return deriva;
    }

  }	//------- Fin Clase AdaptadorPropiedad

}	//------- Fin ES.Reflexion.AdaptadorPropiedad.cs