using UnityEngine;
using System.Collections;

public class spawn_enemies : MonoBehaviour {

	void Update () {
        if (Random.Range(0f,1f) > 0.995f){
	        Instantiate(prefab_manager.enemy_ship, new Vector3(11f,Random.Range(-6f,6f),Random.Range(0.5f,1.0f)), Quaternion.identity);
        }
        if (Random.Range(0f,1f) > 0.997f){
	        Instantiate(prefab_manager.asteroid, Vector3.zero, Quaternion.identity);
        }
	}

}
