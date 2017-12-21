/// <summary>
/// Fernando A. Freire
/// Clase que genera la Grilla de enemigos de manera aleatoria (procedural), y determina el comportamiento 
/// del mismo en conjunto.
/// </summary>

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Funciones;

public class Grilla : MonoBehaviour {
	
	public List<PoolDeObjetos> Enemigos;
	private int TurnoTonoSonido = -1;

	//Sonido
	public AudioSource Sonido;
	public AudioClip[] TonosSonido;
	private int _tiempo;

	void Start(){

		Sonido = transform.GetComponent<AudioSource>();

		VariablesGenerales.ColumnasVigentes = new List<GameObject> ();
		foreach (Transform t in transform) {
			VariablesGenerales.ColumnasVigentes.Add (t.gameObject);
		}
	}
		

	void OnDisable () {

		CancelInvoke ("Movimiento");

		VariablesGenerales.EnemigosDispoibles = 55;
		VariablesGenerales.TonoSonido = 3;
		VariablesGenerales.VelocidadDePaso = 0.8f;
		transform.Translate(new Vector2(0.0f,0.0f));

		LimpiarGrilla ();	

	}


	public void LimpiarGrilla(){

		VariablesGenerales.ColumnasVigentes.Clear ();

		foreach (Transform t in transform) {
			VariablesGenerales.ColumnasVigentes.Add (t.gameObject);
		}

			foreach (Transform t in transform) {
				for (int i = 0; i < 11; i++) {
					

				t.transform.GetChild (0).gameObject.SetActive (false);
				t.transform.GetChild (0).parent = GameObject.Find("Instancias").transform;

				}
			}

		}



	void OnEnable () {




		VariablesGenerales.Vidas = 2;
		VariablesGenerales.TurnoFila = -1;

		InvokeRepeating ("Movimiento", VariablesGenerales.VelocidadDePaso, VariablesGenerales.VelocidadDePaso);
	
		// Genera Grilla

		for (int i = 0; i < 5; i++) {
	
			Vector2 Pos_X_Y = new Vector2 (0,i);
			InstanciarEnemigos (Pos_X_Y, i, 0);

			for (int o = 1; o < 11; o++) {
				Pos_X_Y = new Vector2 (o,i);
				InstanciarEnemigos (Pos_X_Y, i, o);

			}

		}

		// Posiciona el empty en la pantalla:

		transform.Translate(new Vector2(-4.7f,1.2f));

	}



	void InstanciarEnemigos(Vector2 Pos, int Column, int Fila){

		int AzarEnemigo = Random.Range(0,5);

			GameObject InstanciaEnemigos = FuncionesGenerales.InstanciarObjetoDelPool (Pos, new Quaternion(0,0,0,0) , Enemigos[AzarEnemigo]);
			InstanciaEnemigos.transform.SetParent (this.transform.GetChild(Column));
			InstanciaEnemigos.GetComponent<Enemigos>().ColumnaN = Column;
			InstanciaEnemigos.GetComponent<Enemigos>().FilaN = Fila;
			InstanciaEnemigos.GetComponent<Enemigos> ().DependenciaDeLista = transform.GetChild(Column).gameObject;

			InstanciaEnemigos.SetActive (true);
	}



	void Movimiento(){

		VariablesGenerales.TurnoFila = FuncionesGenerales.Turnos (VariablesGenerales.TurnoFila, VariablesGenerales.ColumnasVigentes.Count-1);
		TurnoTonoSonido = FuncionesGenerales.Turnos (TurnoTonoSonido, VariablesGenerales.TonoSonido);

	
		if (VariablesGenerales.TurnoFila == 0)
			VariablesGenerales.Conmutar_CuadroAnimacion = !VariablesGenerales.Conmutar_CuadroAnimacion;



	
		if (VariablesGenerales.Conmutar_DireccionEnemigos) 
			VariablesGenerales.ColumnasVigentes[VariablesGenerales.TurnoFila].transform.Translate (new Vector2 (-0.5f, 0f));
		 else 
			 VariablesGenerales.ColumnasVigentes[VariablesGenerales.TurnoFila].transform.Translate (new Vector2 (0.5f, 0f));


		if (VariablesGenerales.Conmutar_AlturaEnemigos) {
		 VariablesGenerales.ColumnasVigentes[VariablesGenerales.TurnoFila].transform.Translate (new Vector2 (0f, -0.5f));


			if (VariablesGenerales.TurnoFila >= (VariablesGenerales.ColumnasVigentes.Count-1)) {
				VariablesGenerales.Conmutar_AlturaEnemigos = false; 
			

				if (VariablesGenerales.VelocidadDePaso > 0.001f) {
					VariablesGenerales.VelocidadDePaso -= (VariablesGenerales.VelocidadDePaso / 5);
					CancelInvoke ("Movimiento");
					InvokeRepeating ("Movimiento", VariablesGenerales.VelocidadDePaso, VariablesGenerales.VelocidadDePaso);
				}
			}


		}

			
		Sonido.PlayOneShot (TonosSonido [TurnoTonoSonido]);

		}

}
