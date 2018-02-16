
namespace Ekia.EsquemaBasico.Tipos {
  /*-----------------------------------------
     I n t e r f a z   p a r a   M o d e l o  
    -----------------------------------------*/

  public interface IModelo {
    bool EstadoValido { get; }
    bool EstadoEditado { get; }
    IReflexion Reflexion { get; }
    void Actualizar( string propiedad, IValorEstado valor );
    void MarcarLimpio();
  }

}	//------- Fin ES.Tipos.Modelo.IModelo.cs

