using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Funciones;

public class Camara : MonoBehaviour {


	public List<Transform> Posiciones;

	private int PuntoPresente;
	private float VelocidadMovimiento;
	private int _tiempo;

	// Sacudidas
	private Vector3 PosicionPivote;
	public float Duracion;

	void Update(){


		if (VariablesGenerales.Pantalla == 1) {
			PuntoPresente = 0;
			VelocidadMovimiento = 0.3f;
		}



		else{ 
				
			if (_tiempo < 0)
				PuntoPresente = 1;
				

			if (FuncionesGenerales.TiempoSegundos (5, out _tiempo)) {
				VelocidadMovimiento = Random.Range (0.3f, 0.8f);
				PuntoPresente = Random.Range (1, Posiciones.Count);

			}
		}

		MoverCamara (VelocidadMovimiento);

		// Sacudidas:

		if (Duracion > 0) {
			SacudidiCamara ();
		} else {
			Duracion = 0;
			transform.localPosition = PosicionPivote;
		}
	}

	void Start () {
		
		PuntoPresente = 0;
		MoverCamara (VelocidadMovimiento);


	}
	void OnEnable ()
	{
		_tiempo = -1;
		PosicionPivote = transform.localPosition;

	}

	void MoverCamara(float velocidad){
		
		transform.position = Vector3.Slerp (transform.position, Posiciones [PuntoPresente].position, velocidad);
		transform.rotation = Quaternion.Slerp (transform.rotation, Posiciones [PuntoPresente].rotation, velocidad);
		PosicionPivote = transform.localPosition;
	}

	void SacudidiCamara(){

		transform.localPosition = PosicionPivote + Random.insideUnitSphere * 0.7f;
		Duracion -= Time.deltaTime * 1.0f;
	}


}
