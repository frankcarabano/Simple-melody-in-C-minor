/*
 	Clase				  ArchivoPlano
 	
 	Alcance			  Pública
 	
 	Lenguaje			C#
 	
 	Descripción		Permite escribir / leer archivos de texto planos.
 						    Código base tomado del libro: "Introduction to Design Patterns in C#". Copyright 2002 by James W. Cooper.
 					
 						    Campos privados:
 								   nombreArchivo		 string			  Nombre del archivo
 							
 								   lector				     StreamReader	Flujo de datos de lectura
 							
 								   escritor				   StreamWriter	Flujo de datos de escritura
 							
 								   abierto				   bool				  Bandera que indica si el archivo está abierto
 																			            para lectura
 														
 								   abiertoEscritura  bool				  Bandera que indica si el archivo está abierto 
 																			            para escritura
 														
 								   finArchivo			   bool				  Bandera que indica si es Fin-de-archivo en la
 																			            operación de lectura de datos
 					
 						     Propiedades:
 								   FinArchivo			   bool				  Bandera que indica si es Fin-de-archivo
 						
 						     Métodos:
								   inicializar								    Establece los datos básicos de la clase
			
								   guardar									      Escribe el contenido de los buffers y cierra
																			            el archivo
			
								   Cerrar									        Cierra el archivo
		
								   AbrirParaLectura						    Crea un StreamReader para la leer caracteres 
																			            del archivo
		
								   LeerLinea								      Lee una línea de caracteres del archivo
		
								   EscribirLinea							    Escribe una línea de caracteres al archivo
		
								   AbrirParaEscritura					    Crea un StreamWriter para escribir caracteres
																			            en el archivo
 						
 							
 					
 	Autor				 James Cooper. Adaptación realizada por Francisco Carabaño.
 	
 	Creación		 Adaptación realizada el 19/09/2011.
 	
 	
 	Registro de modificaciones:
 	
 	Autor					Fecha			Comentarios
 	==============================================================================================================
 
*/

// Referencias

using System;
using System.IO;

namespace Ekia.EsquemaBasico.AdaptacionLibroJCooper {
  public class ArchivoPlano : IDisposable {
    /* Campos privados */
    string nombreArchivo;
    StreamReader lector;
    StreamWriter escritor;
    bool abierto;
    bool abiertoEscritura;
    bool modificado;
    bool finArchivo;
    int totalLineas;

    /* Constructores */

    public ArchivoPlano() {
      inicializar();
    }

    public ArchivoPlano( string nombre_archivo ) {
      nombreArchivo = nombre_archivo;
      inicializar();
    }

    public void Dispose() {
      if ( lector != null ) {
        lector.Close();
        lector = null;
      }
      if ( escritor != null ) {
        escritor.Close();
        escritor = null;
      }
    }

    /* Propiedad FinArchivo */

    public bool FinArchivo {
      get { return finArchivo; }
    }

    /* Propiedad TotalLineas */

    public int TotalLineas {
      get { return totalLineas; }
    }
    
    /* Método incializar */

    void inicializar() {
      abierto = false;
      abiertoEscritura = false;
      modificado = false;
      finArchivo = false;
      totalLineas = 0;
    }

    /* Método guardar */

    void guardar() {
      escritor.Flush();
      escritor.Close();
      abiertoEscritura = false;
    }

    /* Método Cerrar */

    public void Cerrar() {
      if ( abiertoEscritura ) {
        guardar();
      }

      if ( abierto ) {
        lector.Close();
        abierto = false;
      }
    }

    /* Método AbrirParaLectura - con nombre de archivo pasado como parámetro */

    public bool AbrirParaLectura( string nombre_archivo ) {
      nombreArchivo = nombre_archivo;

      Cerrar();

      try {
        lector = new StreamReader( nombreArchivo );
        abierto = true;
        totalLineas = contarLineas();
        if (totalLineas > 0) {
          Cerrar();
          lector = new StreamReader( nombreArchivo );
        }
      }
      catch ( FileNotFoundException e ) {
        return false;
      }
      return true;
    }

    /* Método AbrirParaLectura - usando el nombre de archivo pasado en el constructor */

    public bool AbrirParaLectura() {
      return AbrirParaLectura( nombreArchivo );
    }

    /* Método LeerLinea */

    public string LeerLinea() {
      string s = "";

      if ( lector.Peek() > 0 ) {
        s = lector.ReadLine();
      }
      else {
        finArchivo = true;
      }

      return s;
    }

    /* Método EscribirLinea */

    public void EscribirLinea( string linea ) {
      escritor.WriteLine( linea );
    }

    /* Método AbrirParaEscritura - con nombre de archivo pasado como argumento */

    public bool AbrirParaEscritura( string nombre_archivo, bool agregar ) {
      Cerrar();

      try {
        escritor = new StreamWriter( nombre_archivo, agregar );
        nombreArchivo = nombre_archivo;
        abiertoEscritura = true;
        return true;
      }
      catch ( FileNotFoundException e ) {
        return false;
      }
    }

    /* Método AbrirParaEscritura - usando el nombre de archivo pasado en el constructor */

    public bool AbrirParaEscritura( bool agregar ) {
      return AbrirParaEscritura( nombreArchivo, agregar );
    }
    
    int contarLineas() {
      int conteo = 0;
      while (!finArchivo) {
          LeerLinea();
          conteo++;
      }
      return conteo;
    }
    
  } //------- fin clase ArchivoPlano
  
} //------- fin Adaptacion.ArchivoPlano.cs