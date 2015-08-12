using UnityEngine;
using System.Collections;

public class player_bullet_hit : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
	    if (col.gameObject.tag == "enemy"){
            Instantiate(prefab_manager.small_explosion, col.gameObject.transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            audio_manager.explode();

            score_manager.score += 10f;
            score_manager.set_addition("+10");
        }
    }
}
