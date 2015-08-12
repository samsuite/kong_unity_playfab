using UnityEngine;
using System.Collections;

public class bullet_move : MonoBehaviour {

    public float speed = 0.225f;

	void Start () {
	
	}
	
	void Update () {
	    transform.Translate(speed*60f*Time.deltaTime,0f,0f);

        if (transform.position.x > 11 || transform.position.x < -11){
            Destroy(this.gameObject);
        }
	}
}
