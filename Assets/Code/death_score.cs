using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using PlayFab;
using PlayFab.ClientModels;

public class death_score : MonoBehaviour {

    public Text final_score;
    public Text high_score;

    public Button menu_button;
    public string next_scene_name;

	void Start () {

        if (data_manager.highScore < score_manager.score){
            data_manager.highScore = score_manager.score;
            data_manager.save_user_data();
        }

        final_score.text = "FINAL SCORE: " + Mathf.Floor(score_manager.score).ToString();
        high_score.text = "HIGH SCORE: " + Mathf.Floor(data_manager.highScore).ToString();

        menu_button.onClick.AddListener(delegate { menu(); });
	}
	
	void menu (){
        health_manager.health = 100f;
        score_manager.score = 0f;
        move_player.vel = Vector2.zero;
        Application.LoadLevel(next_scene_name);
    }
}
