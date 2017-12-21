using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Funciones;

public class Enemigos : MonoBehaviour {


	public int ColumnaN;
	public int FilaN;
	public Transform NodoPadre;

	public GameObject DependenciaDeLista;


	public PoolDeObjetos Balas;
	public PoolDeObjetos Explosion;



	void OnEnable(){

		float rand_tiempo = Random.Range (2.0f, 8.05f);
		InvokeRepeating ("Disparo", rand_tiempo, 4.0f);

		Balas = GameObject.Find ("BalasEnemigos").transform.GetComponent<PoolDeObjetos> ();
		Explosion = GameObject.Find ("Explosiones").transform.GetComponent<PoolDeObjetos> ();

	}



	void Start() {
		
		NodoPadre = transform.parent.transform.parent;
	
	}


	void OnTriggerEnter2D (Collider2D Coll){


		if (Coll.tag == "Borde") {
	

				if (ColumnaN >= 4) {
					VariablesGenerales.Conmutar_DireccionEnemigos = !VariablesGenerales.Conmutar_DireccionEnemigos;
					VariablesGenerales.Conmutar_AlturaEnemigos = true;
					
				} else {
				
				if (!NodoPadre.GetChild (ColumnaN + 1).GetChild (FilaN).gameObject.activeInHierarchy) {
							
							VariablesGenerales.TurnoFila = -1;
							VariablesGenerales.Conmutar_AlturaEnemigos = true;
							VariablesGenerales.Conmutar_DireccionEnemigos = !VariablesGenerales.Conmutar_DireccionEnemigos; 
							

						}
					}
		
				} 
			} 
		


	void OnCollisionEnter2D (Collision2D Coll){

		// al colicionar con una bala
		if (Coll.collider.tag == "Player") {

				transform.gameObject.SetActive (false);
				FuncionesGenerales.ActualizaScore ();
	
		}

		if (Coll.collider.name == "Player") {
			VariablesGenerales.Vidas = 0;
		}
			
	}
		


	void OnDisable(){

		if (VariablesGenerales.Pantalla > 1) {
			GameObject Exp = FuncionesGenerales.InstanciarObjetoDelPool (transform.position, Quaternion.identity, Explosion); // Explosion;
			Exp.SetActive(true);

			if (!FuncionesGenerales.EnemigosVigentesEnFila (transform.parent)) {
				VariablesGenerales.ColumnasVigentes.Remove (DependenciaDeLista);
				if (ColumnaN != 0 && ColumnaN != 4)
					VariablesGenerales.TonoSonido -= 1;
			}
			
		}

		CancelInvoke ("Disparo");


		if (this.transform.parent != null) { 

			if (VariablesGenerales.Pantalla > 1)
			FuncionesGenerales.BuscarVecinoSimilar (ColumnaN, FilaN, this.transform); 

			VariablesGenerales.MultiScore += 1;
			VariablesGenerales.EnemigosDispoibles -= 1; 

		}


	}


		void Disparo(){
		
		if (ColumnaN == 0 || (ColumnaN+1) < 5 && transform.parent.transform.parent.GetChild (ColumnaN-1).GetChild (FilaN).gameObject.activeSelf != true) {
			
			GameObject Instancia_Bala = FuncionesGenerales.InstanciarObjetoDelPool ((transform.position + new Vector3 (0f, -1.0f, 0f)), Quaternion.identity, Balas);
			if (Instancia_Bala != null) Instancia_Bala.SetActive (true);

		
				}

			}

		}











