using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Funciones;

public class UI : MonoBehaviour {

	public Text Score;
	public Text Detalles;
	public Text ConteoVidas;
	public RawImage[] Vidas;
	public Image Daños;

	void OnEnable(){
		
		mostrar_vidas (2, true); // recarga las vidas en la pantalla
		Daños.enabled = false;

	}

	// Update is called once per frame
	void Update () {
	
		Score.text = VariablesGenerales.Score.ToString();
		Detalles.text = "Enemigos Vigentes: \"" + VariablesGenerales.EnemigosDispoibles + "\" Total Match: \"" + VariablesGenerales.MultiScore + "\" Multiplo Fibonachi:\"" + FuncionesGenerales.Fibonachi(VariablesGenerales.MultiScore) + "\"";
		mostrar_vidas ((2 - VariablesGenerales.Vidas), false); //actualiza estado de vidas

		ConteoVidas.text = "Vidas (" + (VariablesGenerales.Vidas+1) + ")";


	}


	void mostrar_vidas(int vidas, bool activa){
		
		for (int i = 0; i < vidas; i++){
			Vidas[i].enabled = activa;
		}

	}

	public void AplicarDaños()
	{	

		Daños.enabled = true;
		Daños.CrossFadeAlpha (1.0f, 0.1f, false);
		Daños.CrossFadeAlpha (0.0f, 1.2f, false);

	}


}
