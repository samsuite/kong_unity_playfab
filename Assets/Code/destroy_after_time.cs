using UnityEngine;
using System.Collections;

public class destroy_after_time : MonoBehaviour {

    public float lifetime;
    float timer;
	
	void Update () {
        timer += Time.deltaTime;

        if (timer>= lifetime){
            Destroy(this.gameObject);
        }
	}
}