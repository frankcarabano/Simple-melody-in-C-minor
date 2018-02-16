using System.Collections;
using System.Collections.Generic;
using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Reflexion {
  /*-------------------------------------------
     L i s t a   d e   P r o p i e d a d e s  
    -------------------------------------------*/

  public class ListaPropiedades : IListaPropiedades {
    IList<IAdaptadorPtyInf> lista;

    internal ListaPropiedades() {
      this.lista = new List<IAdaptadorPtyInf>();
    }

    public IAdaptadorPtyInf this[string nombre] {			// indexador, por Nombre de AdaptadorPropiedad
      get {
        IAdaptadorPtyInf resultado = null;
        foreach ( IAdaptadorPtyInf p in this.lista ) {
          if ( p.Nombre == nombre ) {
            resultado = p;
            break;
          }
        }
        return resultado;
      }
    }

    public ICollection Lista {
      get { return ( this.lista as List<IAdaptadorPtyInf> ).AsReadOnly(); }
    }

    public string[] Nombres {										// arreglo de Nombres de Propiedades
      get {
        string[] nombres = new string[this.lista.Count];
        int i = 0;
        foreach ( IAdaptadorPtyInf p in this.lista ) {
          nombres[i++] = p.Nombre;
        }
        return nombres;
      }
    }

    public int Conteo {
      get { return this.lista.Count; }
    }

    public void Agregar( IAdaptadorPtyInf propiedad ) {
      this.lista.Add( propiedad );
    }

  }	//------- Fin Clase ListaPropiedades

}	//------- Fin ES.Reflexion.ListaPropiedades.cs