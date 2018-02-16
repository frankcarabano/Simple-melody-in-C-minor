using Ekia.EsquemaBasico.Tipos;

namespace Ekia.EsquemaBasico.Listas {
  /*-----------------------------------------------------------
     C l a s e   b a s e   p a r a   e l   e s t a d o   d e l
               C o n t r o l a d o r   d e   L i s t a s
                u s a d a   p o r   e l   M e m e n t o
    -----------------------------------------------------------*/

  public abstract class EstadoControlador<TInstancia> {
    protected EstadosEdicionFichero estadoEdicionFichero;
    protected EstadosEdicionInstancias estadoEdicionInstancia;
    protected TInstancia instancia;

    public EstadoControlador( EstadosEdicionFichero edoLst, EstadosEdicionInstancias edoElm, IClonable<TInstancia> origen ) {
      this.estadoEdicionFichero = edoLst;
      this.estadoEdicionInstancia = edoElm;
      guardarEstadoInstancia( origen );
    }

    public EstadosEdicionFichero EstadoEdicionFichero {
      get { return this.estadoEdicionFichero; }
    }

    public EstadosEdicionInstancias EstadoEdicionElemento {
      get { return this.estadoEdicionInstancia; }
    }

    public object Elemento {
      get { return this.instancia; }
    }

    protected void guardarEstadoInstancia( IClonable<TInstancia> origen ) {
      if ( ( origen as object ) != null ) {
        this.instancia = origen.Clonar();
      }
      else {
        anularInstancia();
      }
    }

    protected abstract void anularInstancia();

  }	//------- Fin clase EstadoControlador

}	//------- Fin ES.Listas.EstadoControlador.cs