using UnityEngine;
using System.Collections;
using Funciones;

public class Player : MonoBehaviour {


	public PoolDeObjetos Balas;
	public GameObject Instancia_Bala;
	public AudioSource Sonido;
	public AudioClip Impacto;
	public UI ImpactoCamara;
	private bool v = true; //solo una vez por golpe;

	void Start()
	{
		Sonido = transform.GetComponent<AudioSource> ();
		ImpactoCamara = transform.parent.FindChild ("UI").GetComponent<UI> ();
	}

	void Update () {
	
		v = true;

		// Movimiento por Axis del player:

		float AxisHorizontal = Input.GetAxis ("Horizontal");
		transform.Translate (Vector2.right * AxisHorizontal * Time.deltaTime * 10);
		transform.position = new Vector2(transform.position.x, -5.72f);

		if(Input.GetKeyDown (KeyCode.Space)){

			Disparo();

		}
	}

	void OnEnable(){
		transform.position = new Vector3 (0f, -5.72f, 0f);
		VariablesGenerales.Vidas = 2;
	}



	void OnTriggerEnter2D(Collider2D Coll){

		// Recepción de Impactos:

		if (Coll.tag == "Enemigo") {
			
			if (v) { VariablesGenerales.Vidas -= 1; v = false; } //solo una vez por golpe;
			Coll.gameObject.SetActive (false);
			Sonido.PlayOneShot (Impacto);
			ImpactoCamara.AplicarDaños ();
		}

	}



	void Disparo(){

		VariablesGenerales.MultiScore = 0;

		Instancia_Bala = FuncionesGenerales.InstanciarObjetoDelPool (transform.position + new Vector3 (0f, 1.0f, 0f), Quaternion.identity, Balas);

		if (Instancia_Bala != null) {
			
			Instancia_Bala.SetActive (true);
			Sonido.Play ();
		


	
		}
	}


}
