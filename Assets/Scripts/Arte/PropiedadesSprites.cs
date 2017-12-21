using UnityEngine;
using System.Collections;
using Funciones;

public class PropiedadesSprites : MonoBehaviour {


	private Renderer _Ren;

	public Vector2 Tilled;
	public Vector2 Offset;

	public Vector2 CambioOffset;


	void Start () {

		_Ren = GetComponent<Renderer>();

	}
	
	void Update () {

		if (VariablesGenerales.Conmutar_CuadroAnimacion) {
			FuncionesGenerales.CambiarTileyOffset (Tilled, Offset, _Ren);
		} else {
			FuncionesGenerales.CambiarTileyOffset (Tilled, CambioOffset, _Ren);
		}

	}



}
