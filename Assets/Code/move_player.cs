using UnityEngine;
using System.Collections;

public class move_player : MonoBehaviour {

    public static Vector2 vel = new Vector2(0f,0f);
    float a_hor;
    float a_ver;

    float accel = 0.03f;
    float drag = 0.15f;

    float cooldown_timer = 0f;
    float cooldown = 0.333f;
    float anim_timer = 0f;

    public GameObject bullet;
    public GameObject fire;
    public GameObject shoot_anim;
    
    AudioSource shoot_source;

    void Start () {
        shoot_source = gameObject.GetComponent<AudioSource>();
    }

	void Update () {

        //health_manager.health -= 0.1f;

        if (anim_timer > 0f){
            anim_timer -= Time.deltaTime;
            shoot_anim.SetActive(true);
        }
        else {
            shoot_anim.SetActive(false);
        }

        if (cooldown_timer > 0){
            cooldown_timer -= Time.deltaTime;
        }

        if (Input.GetButton("Fire") && cooldown_timer <= 0 && health_manager.health > 0f){
            cooldown_timer = cooldown;
            vel.x -= 0.3f;
            anim_timer = 0.05f;
            Instantiate(bullet,transform.position + Vector3.forward, transform.rotation);
            shoot_source.Play();
        }

        a_hor = Input.GetAxis("Horizontal") * accel;
        a_ver = Input.GetAxis("Vertical") * accel;

        if (health_manager.health <= 0f){
            a_hor = 0f;
            a_ver = 0f;
        }

        vel.x += a_hor*Time.deltaTime*60f;
        vel.y += a_ver*Time.deltaTime*60f;
        vel /= 1 + (drag*Time.deltaTime*60f);

        transform.position = new Vector3(transform.position.x + vel.x, transform.position.y + vel.y, transform.position.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, vel.y*80f + vel.x*-40f);
        fire.transform.localScale = new Vector3(0.67f + vel.x*2f, 0.67f + vel.x/2f, 0.67f);

        if (transform.position.x > 9f){
            transform.position = new Vector3 (9f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -9f){
            transform.position = new Vector3 (-9f, transform.position.y, transform.position.z);
        }

        if (transform.position.y > 6.75f){
            transform.position = new Vector3 (transform.position.x, 6.75f, transform.position.z);
        }
        else if (transform.position.y < -6.75f){
            transform.position = new Vector3 (transform.position.x, -6.75f, transform.position.z);
        }

        vel += new Vector2(-(0.005f - health_manager.health/20000f), -(0.005f - health_manager.health/20000f));
    }
}
