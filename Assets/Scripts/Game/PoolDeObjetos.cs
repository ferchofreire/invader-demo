// ObjectPool para la precarga de Objetos en memoria y la re-utilización de estos.

using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 
 public class PoolDeObjetos : MonoBehaviour
 {

	// Carga de Objetos al Pool
	public GameObject ObjetosACargar;
	public int CantidadDeInstancias = 20;
	public bool Extencible = true;
	// GameObject donde depositará los objetos
	public string ListaEmpty = "";

    public List<GameObject> ObjetosEnMemoria;
    

     void Start ()
     {
		ObjetosEnMemoria = new List<GameObject>();
		for(int i = 0; i < CantidadDeInstancias; i++)
         {
			GameObject obj = (GameObject)Instantiate(ObjetosACargar);
             obj.SetActive(false);
			ObjetosEnMemoria.Add(obj);
			obj.transform.parent = GameObject.Find (ListaEmpty).transform;
         }
     }
 
     public GameObject CargarObjetoDeMemoria()
     {
		for(int i = 0; i< ObjetosEnMemoria.Count; i++)
         {
			if(ObjetosEnMemoria[i] == null)
             {
				GameObject obj = (GameObject)Instantiate(ObjetosACargar);
                 obj.SetActive(false);
				ObjetosEnMemoria[i] = obj;
				return ObjetosEnMemoria[i];
             }
			if(!ObjetosEnMemoria[i].activeInHierarchy)
             {
				return ObjetosEnMemoria[i];
             }    
         }
         
		if (Extencible)
         {
			GameObject obj = (GameObject)Instantiate(ObjetosACargar);
			ObjetosEnMemoria.Add(obj);
			obj.transform.parent = GameObject.Find (ListaEmpty).transform;
             return obj;
         }
         
         return null;
     }


	public void UltimoElimina(){

		// for(int i = pooledObjects.Count - 1; i --> 0; i--)
		///{
			
		if(ObjetosEnMemoria[ObjetosEnMemoria.Count - 1].activeInHierarchy)
			{
			ObjetosEnMemoria [ObjetosEnMemoria.Count - 1].SetActive (false);
				// break;
			}  	
		
	//}
     
 }

}