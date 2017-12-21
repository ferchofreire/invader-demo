using UnityEngine;
using System.Collections;

public class Protecciones: MonoBehaviour {

	public Transform InstanciasMarcas; 

	private BoxCollider2D[] Collids;
	private int Vida = 5;
	private AudioSource Sonido;
	public Camara SacudidasCamara;

	void Start(){

		Collids = gameObject.GetComponents<BoxCollider2D> ();
		Sonido = transform.GetComponent<AudioSource> ();

	}

	void OnDisable () {

		Vida = 5;
		if(VariablesGenerales.Pantalla == 1){

		foreach(BoxCollider2D BC in Collids) BC.enabled = true;
		transform.GetChild (0).gameObject.SetActive (false);

			foreach (Transform t in InstanciasMarcas) {
			
				if (t.name == "Roto(Clone)")
					t.gameObject.SetActive (false);
			
			}
		}
	}



	private bool v = true;

	void Update(){
		v = true;
	}

	void OnTriggerEnter2D(Collider2D Coll){
		

		if (Coll.tag == "Enemigo") {
	
		
			if (v) { Vida -= 1; v = false; } // solo una vida por golpe.


			if (Vida <= 1) {
				transform.GetChild (0).gameObject.SetActive (true);
				SacudidasCamara.Duracion = 0.3f;
				Sonido.Play();
			}

		}
	}


}
