using UnityEngine;
using System.Collections;
using Funciones;


public class Balas : MonoBehaviour {

	public PoolDeObjetos Marcas;
	public PoolDeObjetos Explocion;

	public Vector2 Direccion;
	void Start(){

		Marcas = GameObject.Find ("Rotos").transform.GetComponent<PoolDeObjetos> (); 
		Explocion = GameObject.Find ("Explosiones").transform.GetComponent<PoolDeObjetos> ();
	}

	void FixedUpdate(){

		transform.Translate(Direccion);
	}

	void Update(){
		
		if (VariablesGenerales.Pantalla == 1)
			this.gameObject.SetActive (false);

		if (this.transform.position.y > 5.0f || this.transform.position.y < -7.2f)
			this.gameObject.SetActive(false); 
	}

	void OnCollisionEnter2D(Collision2D Coll)
	{ 


		if (Coll.collider.name == "Balas 1(Clone)" || Coll.collider.tag == "Balas 2(Clone)") {
			Instanciar (Explocion);
			transform.gameObject.SetActive (false);
		}

		this.gameObject.SetActive (false);

	}

	void OnTriggerEnter2D(Collider2D Coll){

		if (Coll.tag == "Barrera" && transform.tag == "Enemigo") {

					Coll.enabled = false;
					Instanciar (Marcas);
					Instanciar (Explocion);
			}
		if (Coll.tag == "Player")
					Instanciar (Explocion);
	
	}


	void Instanciar(PoolDeObjetos Tipo)
	{
		GameObject Instancia = FuncionesGenerales.InstanciarObjetoDelPool (this.transform.position, Quaternion.identity, Tipo);
		Instancia.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
