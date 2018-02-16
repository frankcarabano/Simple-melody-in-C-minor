using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
  /*-----------------------------------------------------------------------------------
           C l a s e   p a r a   c o m a n d o s   d e l   c o n t r o l a d o r 
	   
     Las instancias de esta clase corresponderan con los widgets para activacion de
     los comandos en las implementaciones de la interfaz IVistaLista
    ----------------------------------------------------------------------------------*/

  // Apunta a una operacion del controlador

  public delegate void OperacionControladorIr( int indice );

  public class ComandoIr : IComando {
    OperacionControladorIr operacion;
    IVistaFicheroMaestro vista;
    int posicionElemento;

    public ComandoIr( OperacionControladorIr oprc, int posicion, IVistaFicheroMaestro vist ) {
      this.operacion = oprc;
      this.vista = vist;
      this.posicionElemento = posicion;
    }
    public void Ejecutar() {
      this.operacion( this.posicionElemento );
      this.vista.ReflejarEstadoEdicion();
    }
  }

}	//------- Fin ES.Listas.ComandoIr.cs