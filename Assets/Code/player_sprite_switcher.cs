using UnityEngine;
using System.Collections;

public class player_sprite_switcher : MonoBehaviour {

    public Sprite destroyedship;
    public Sprite greenship_1;
    public Sprite greenship_2;
    public Sprite greenship_3;
    public Sprite greenship_4;
    public Sprite greenship_5;
    public Sprite orangeship_1;
    public Sprite orangeship_2;
    public Sprite orangeship_3;
    public Sprite orangeship_4;
    public Sprite orangeship_5;
    SpriteRenderer renderer;

    float stored_health = 100f;

	// Use this for initialization
	void Start () {
	    renderer = GetComponent<SpriteRenderer>();

        if (data_manager.shipColor == "green"){
            renderer.sprite = greenship_1;
        }
        else {
            renderer.sprite = orangeship_1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (stored_health > health_manager.health){
            stored_health = health_manager.health;

            if (stored_health <= 0f){
                renderer.sprite = destroyedship;
            }
            else {
	            if (data_manager.shipColor == "green"){

                    if (stored_health < 20f){
                        renderer.sprite = greenship_5;
                    }
                    else if (stored_health < 40f){
                        renderer.sprite = greenship_4;
                    }
                    else if (stored_health < 60f){
                        renderer.sprite = greenship_3;
                    }
                    else if (stored_health < 80f){
                        renderer.sprite = greenship_2;
                    }
                    else {
                        renderer.sprite = greenship_1;
                    }
                }
                else if (data_manager.shipColor == "orange"){

                    if (stored_health < 20f){
                        renderer.sprite = orangeship_5;
                    }
                    else if (stored_health < 40f){
                        renderer.sprite = orangeship_4;
                    }
                    else if (stored_health < 60f){
                        renderer.sprite = orangeship_3;
                    }
                    else if (stored_health < 80f){
                        renderer.sprite = orangeship_2;
                    }
                    else {
                        renderer.sprite = orangeship_1;
                    }
                }
            }
        }
	}
}
