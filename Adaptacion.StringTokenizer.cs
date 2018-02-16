/*
 	Clase				StringTokenizer
 	
 	Alcance			Publica
 	
 	Lenguaje			C#
 	
 	Descripción		Separar un texto en "tokens". Código base tomado del libro:
 						"Introduction to Design Patterns in C#". Copyright 2002 by James W. Cooper.
 					
 						Campos privados:
 					
 						Propiedades:
 						
 						Métodos:
 						
 							
 					
 	Autor				James Cooper. Adaptación realizada por Francisco Carabaño.
 	
 	Creación			Adaptación realizada el 24/09/2011.
 	
 	
 	Registro de modificaciones:
 	
 	Autor					Fecha			Comentarios
 	==============================================================================================================
 
*/

// Referencias

using System;
using System.Collections.Generic;

namespace Ekia.EsquemaBasico.AdaptacionLibroJCooper {
  public class StringTokenizer {
    Queue<string> colaTokens;

    public StringTokenizer( string lineaTexto ) {
      inicializar( lineaTexto, " " );
    }

    public StringTokenizer( string lineaTexto, string delim ) {
      inicializar( lineaTexto, delim );
    }

    public int CuentaTokens {
      get { return this.colaTokens.Count; }
    }

    public bool HayMasTokens() {
      return this.colaTokens.Count > 0;
    }

    public string ProximoToken() {
      string token = string.Empty;
      if ( HayMasTokens() ) {
        token = (string)this.colaTokens.Dequeue();
      }
      return token;
    }

    public string[] Tokens() {
      return this.colaTokens.ToArray();
    }

    void inicializar( string linTxt, string del ) {
      encolarTokens( linTxt.Split( del.ToCharArray() ) );
    }

    void encolarTokens( string[] tokens ) {
      this.colaTokens = new Queue<string>();
      foreach ( string token in tokens ) {
        this.colaTokens.Enqueue( token );
      }
    }

  }	//------- Fin Clase StringTokenizer

}	//------- Fin StringTokenizer.cs