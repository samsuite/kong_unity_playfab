using UnityEngine;
using System.Collections;

public class asteroid_move : MonoBehaviour {

    float size;
    float xv;
    float yv;
    float rv;
    SpriteRenderer renderer;

    public Sprite asteroid1;
    public Sprite asteroid2;

	void Start () {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = asteroid1;

	    size = Random.Range(0.5f,1.5f);
        xv = Random.Range(-2.5f,2.5f);
        yv = Random.Range(-2.5f,2.5f);
        rv = Random.Range(-150f,150f);

        transform.localScale = Vector3.zero;
        transform.position = new Vector3(0f,0f,3f);
	}
	
	void Update () {
        transform.eulerAngles += new Vector3(0f,0f,rv*Time.deltaTime);
        if (transform.localScale.x < size){
	        transform.localScale += new Vector3(Time.deltaTime/2f, Time.deltaTime/2f, Time.deltaTime/2f);
            transform.position += new Vector3(xv*Time.deltaTime, yv*Time.deltaTime, 0f);
        }
        else {
            renderer.sprite = asteroid2;
        }
	}

    void OnTriggerEnter2D(Collider2D col) {
	    if (col.gameObject.tag == "player" && transform.localScale.x >= size){
            health_manager.health -= 10f;
            move_player.vel -= move_player.vel.normalized*0.5f;
        }
        else if (col.gameObject.tag == "red bullet" && transform.localScale.x >= size){
            Instantiate(prefab_manager.small_explosion, gameObject.transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            
            score_manager.score += 15f;
            score_manager.set_addition("+15");

            audio_manager.explode();
        }
    }
}
