using UnityEngine;
using System.Collections;

public class enemy_ship : MonoBehaviour {

    float start_time;
    float cooldown = 1.66f;
    float cooldown_timer = 0f;

    AudioSource sound_source;

	void Start () {
	    start_time = Time.time;
        sound_source = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
	    transform.eulerAngles = new Vector3(0f,0f, Mathf.Sin((Time.time-start_time)*4f)* 8f);
        transform.position = new Vector3 (transform.position.x-Time.deltaTime*2f,transform.position.y, transform.position.z);

        if (transform.position.x < -11){
            Destroy(this.gameObject);
        }

        cooldown_timer -= Time.deltaTime;
        if (cooldown_timer <= 0f){
            cooldown_timer += cooldown;
            Instantiate(prefab_manager.blue_bullet, transform.position + new Vector3 (0f,0f,0.1f), Quaternion.identity);
            sound_source.Play();
        }
	}
}
