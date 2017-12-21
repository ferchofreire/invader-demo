/// <summary>
/// Fernando A. Freire
/// Variables que determinan todos los estados del juego, desde la dirección de los enemigos, las alturas, el recuento
/// Estado juego, pantallas.
/// </summary>
using System.Collections.Generic;
using UnityEngine;

public static class VariablesGenerales {

	// Movimiento Grilla de Enemigos:
	public static bool Conmutar_CuadroAnimacion;
	public static bool Conmutar_DireccionEnemigos;
	public static bool Conmutar_AlturaEnemigos;
	public static int TurnoFila;
	public static List<GameObject> ColumnasVigentes;


	public static int TonoSonido = 3;
	public static float VelocidadDePaso = 0.8f;


	// Pantallas (Menu 1, GamePlay 2, GameOver 3):
	public static int Pantalla = 1;

	// Recuento de Score: 
	public static float Score = 0;
	public static int MultiScore;

	// Datos Adicionales tras el cambio de pantalla:
	public static float EnemigosDispoibles = 55;

	// Estado del Player:
	public static int Vidas = 2;

}
