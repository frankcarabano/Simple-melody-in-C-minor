using System;
using Ekia.EsquemaBasico.Tipos;
using Ekia.EsquemaBasico.Reflexion;

namespace Ekia.EsquemaBasico.Listas {
  /*---------------------------------------------------------------------
         C l a s e   b a s e   p a r a   c o n t r o l a d o r   d e     
      P r o p i e d a d e s   -   L i s t a   d e   c l a v e   u n i c a 
    ---------------------------------------------------------------------*/

  public abstract class ControladorPropiedadListaClaveUnica<TInstancia> : ControladorPropiedadLista<TInstancia> {
    public ControladorPropiedadListaClaveUnica( IControladorMV controladorMV, IAdaptadorVista<TInstancia> vista ) : base( controladorMV, vista ) {
    }

    public ControladorPropiedadListaClaveUnica( IPropiedadLista<TInstancia> lista, IControladorMV controladorMV, IAdaptadorVista<TInstancia> vista ) :
                                          base( lista, controladorMV, vista ) {
    }

    public override void ActualizarLista( object sender, EventArgs args ) {
      bool actualizada = true;
      if ( this.esNuevaInstancia ) {													            // si es una instancia nueva
        try {
          this.lista.IncluirInstancia( this.bufferInstancias );           // tratar de incluirla
        }
        catch ( ClaveDuplicada e ) {													            // de estar duplicada la clave
          actualizada = false;														                // no hay actualización
          this.vista.Informar( e.Message );										            // informar al usuario
        }
      }
      else {																				                      // si no es un instancia nuevo
        if ( claveEditada() ) {									                          // si la clave fue editada
          if ( this.lista.ContieneClave( claveInstanciaEnBuffer() ) ) {   // si la clave escrita existe
            this.vista.Informar( crearMensajeClaveDuplicada() );			    // informar al usuario
          }
          else {																		                      // si la clave no existe
            actualizarClave();													                  // actualizar claves
          }
        }
        else {																			                      // si la clave no fue editada
          actualizarInstancia();													                // actualizar instancia
        }
      }
      if ( actualizada ) {																                // si hubo actualizacion
        notificarActualizacion();													                // notificar a los observadores
        crearNuevaInstancia();														                // crear una nueva instancia
      }
    }

    protected abstract string crearMensajeClaveDuplicada();

    string claveInstanciaEnBuffer() {
      return Reflector.ObtenerValorPropiedad( this.bufferInstancias, this.lista.NombreClave ).ToString();
    }

  }	//------- Fin clase ControladorPropiedadLista

}	//------- Fin ES.Listas.ControladorPropiedadLista.cs