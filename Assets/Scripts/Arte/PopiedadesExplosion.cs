using UnityEngine;
using System.Collections;

public class PopiedadesExplosion : MonoBehaviour {


	private Renderer _Ren;

	// vector2 (x,y) del recorte inicial en el SpriteSheet de acuerdo al bitmap:
	public Vector2 Tilled;
	public Vector2[] Cuadros_Offset;

	public float CuadroActual = 0;

	void Start () {
		
		_Ren = GetComponent<Renderer>();

	}
	void OnEnable(){

		CuadroActual = 0;
	}
	

	void Update () {

		CuadroActual += Time.deltaTime;
		if((int)CuadroActual == Cuadros_Offset.Length-1) 
			transform.gameObject.SetActive (false);
		

		_Ren.material.SetTextureOffset ("_MainTex", Cuadros_Offset[(int)CuadroActual]);

	}
}
