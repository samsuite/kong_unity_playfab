using UnityEngine;
using System.Collections;

public class enemy_bullet_hit : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col) {
	    if (col.gameObject.tag == "player"){
            Instantiate(prefab_manager.small_explosion, transform.position, transform.rotation);
            Destroy(this.gameObject);
            health_manager.health -= 10f;
        }
    }
}
