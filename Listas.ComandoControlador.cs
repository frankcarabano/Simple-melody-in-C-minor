using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
	/*-----------------------------------------------------------------------------------
	         C l a s e   p a r a   c o m a n d o s   d e l   c o n t r o l a d o r 
	   
	   Las instancias de esta clase corresponderan con los widgets para activacion de
	   los comandos en las implementaciones de la interfaz IVistaLista
	  ----------------------------------------------------------------------------------*/
	
	// Apunta a una operacion del controlador
	
	public delegate void OperacionControlador();
	
	public class ComandoControlador : IComando {
		OperacionControlador operacion;
		IVistaFicheroMaestro vista;
		
		public ComandoControlador(OperacionControlador oprc, IVistaFicheroMaestro vist) {
			this.operacion = oprc;
			this.vista     = vist;
		}
		public void Ejecutar() {
			this.operacion();									// ejecuta la operacion apuntada
			this.vista.ReflejarEstadoEdicion();
		}
	}

}	//------- Fin ES.Listas.ComandoControlador.cs