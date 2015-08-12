using UnityEngine;
using System.Collections;

public class health_manager : MonoBehaviour {

    public static float health = 100f;
    public RectTransform bar;

    public ParticleSystem smoke;
    public ParticleSystem deathsmoke;
    public string next_scene_name;

    float death_timer = 0f;
    float death_timer_len = 2f;

    bool death_smoke_enabled = false;

    void Start () {
        disable_death_smoke();
    }

	void Update () {
        bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 244.7f * health/100f);

        if (health <= 0f){
            death_timer += Time.deltaTime;
        }
        else if (health < 40f && !death_smoke_enabled){
            enable_death_smoke();
        }
        else if (health >= 40f && death_smoke_enabled){
            disable_death_smoke();
        }

        if (death_timer >= death_timer_len){
            Application.LoadLevel(next_scene_name);
        }
	}

    void enable_death_smoke () {
        smoke.emissionRate = 0f;
        deathsmoke.emissionRate = 350f;
    }
    void disable_death_smoke () {
        smoke.emissionRate = 350f;
        deathsmoke.emissionRate = 0f;
    }
}
