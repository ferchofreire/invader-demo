using UnityEngine;
using System.Collections;


namespace Funciones {

	public static class FuncionesGenerales  {

		public static float _tiempo;

		public static int Turnos(int Actual, int Limite){
			Actual += 1;
			if (Actual > Limite)
				return 0;
			else 
				return Actual;
		
		}



		public static bool TiempoSegundos(int segundos, out int tiempo){
			
			_tiempo += Time.deltaTime;
			if (_tiempo > segundos) {
			_tiempo = 0;
				tiempo = (int)_tiempo;
			return true;
			} else {
				tiempo = (int)_tiempo;
			return false;
			}
	}

		public static int Fibonachi(int Numero){

			int a = 0;
			int b = 1;

			for (int i = 0; i < Numero; i++) {
				int aux = a;
				a = b;
				b += aux;
			}
			return a;
		}

		 public static void ActualizaScore(){

			if (VariablesGenerales.MultiScore != 1)
				VariablesGenerales.Score += (VariablesGenerales.MultiScore * FuncionesGenerales.Fibonachi (VariablesGenerales.MultiScore)) * 10;
			else 
				VariablesGenerales.Score += VariablesGenerales.MultiScore * 10;

		}

		public static GameObject InstanciarObjetoDelPool(Vector3 Posicion, Quaternion Rotacion, PoolDeObjetos Pool){

			if (Pool.gameObject != null) {
			 
				GameObject ObjetoObtenido = Pool.CargarObjetoDeMemoria ();

				if (ObjetoObtenido != null) {
				ObjetoObtenido.transform.position = Posicion;
				ObjetoObtenido.transform.rotation = Rotacion;
				// ObjetoObtenido.gameObject.SetActive (true);
					return ObjetoObtenido;
				} else {
					return null;
				}
					

				
			} else {
				return null;
			}
		}

		public static void BuscarVecinoSimilar(int DesdeColumna, int DesdeFila, Transform Buscador){

			int lado; int altura; int comp;
			int i = 0; bool giro = true;

			do {
				
				if (giro) {
					lado = DesdeFila + 1;  altura = DesdeColumna + 1;  comp = 0;
				} else {
					lado = DesdeFila - 1;  altura = DesdeColumna - 1;  comp = -1;
				}

				if (lado > comp && lado < 11 && Buscador.parent.GetChild (lado).name == Buscador.name)
					Buscador.parent.GetChild (lado).gameObject.SetActive (false);


				if (altura > 0 && altura < 5 && Buscador.parent.transform.parent.GetChild (altura).GetChild (DesdeFila).name == Buscador.name)
					Buscador.parent.transform.parent.GetChild (altura).GetChild (DesdeFila).gameObject.SetActive (false);

				i += 1;
				giro = !giro;

			} while (i < 2);
		

		}

		public static void CambiarTileyOffset(Vector2 tilled, Vector2 Offset, Renderer Imagen){

			Imagen.material.SetTextureScale("_MainTex", tilled);
			Imagen.material.SetTextureOffset ("_MainTex", Offset);
		
		}

		public static int SiEstaFilaVigentesEnGrilla(Transform NodoPadre){
			int NumeroDeFilas = -1;

			foreach (Transform t in NodoPadre) {
				if (t.gameObject.activeInHierarchy)
					NumeroDeFilas += 1;
				
			}

			return NumeroDeFilas;
		}


		public static bool EnemigosVigentesEnFila(Transform NodoPadre){

			int NumerosDeEnemigos = 0;

			foreach (Transform t in NodoPadre) {
				if (t.gameObject.activeInHierarchy) {
					NumerosDeEnemigos += 1;
				}
			}
				if (NumerosDeEnemigos > 0)
					return true;
				else
					return false;
			
		}


	

	}
}

