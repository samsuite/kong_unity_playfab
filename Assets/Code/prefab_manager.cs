using UnityEngine;
using System.Collections;

public class prefab_manager : MonoBehaviour {

    public GameObject red_bullet_input;
    public GameObject blue_bullet_input;
    public GameObject enemy_ship_input;
    public GameObject small_explosion_input;
    public GameObject asteroid_input;

    public static GameObject red_bullet;
    public static GameObject blue_bullet;
    public static GameObject enemy_ship;
    public static GameObject small_explosion;
    public static GameObject asteroid;

	void Start () {
	    red_bullet = red_bullet_input;
        blue_bullet = blue_bullet_input;
        enemy_ship = enemy_ship_input;
        small_explosion = small_explosion_input;
        asteroid = asteroid_input;
	}
	
	void Update () {
	
	}
}
