/// <summary>
/// Fernando A. Freire
/// El GameState controla el estado de las vidas, las torres y cantidad de enemies en pantalla para combiar las pantallas
/// </summary>

using UnityEngine;
using System.Collections;

public class GameState: MonoBehaviour {

	public GameObject Menu;
	public GameObject GamePlay;


	void Update () {


		if (VariablesGenerales.Vidas < 0 ) {
			VariablesGenerales.Pantalla = 1;

		}


		// reinicia el gameplay tras la eliminacion de todos los enemigos

		if (VariablesGenerales.EnemigosDispoibles < 1) {

	
			GamePlay.SetActive(false); 
			VariablesGenerales.EnemigosDispoibles = 55;
			GamePlay.SetActive(true);


		}

		CambioPantalla (VariablesGenerales.Pantalla);

		if(Input.GetKeyUp(KeyCode.Escape)){
			VariablesGenerales.Pantalla -= 1;
		
		}
	}
	
	public void CambioPantalla(int pantalla){
		
			VariablesGenerales.Pantalla = pantalla;

		switch (pantalla) {
		case 0:
			
			print ("Sale Del Juego");
			Application.Quit ();

			break;
		case 1:
			VariablesGenerales.Score = 0;
			GamePlay.SetActive(false);
			Menu.SetActive (true);
		break;
		case 2:
			
			Menu.SetActive (false);
			GamePlay.SetActive(true);
		break;
		}

	}

	
}
