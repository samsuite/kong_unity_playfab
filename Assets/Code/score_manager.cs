using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score_manager : MonoBehaviour {

    public static float score = 0f;
    public Text score_text;
    public Text score_text_addition_input;
    public static Text score_text_addition;

    public Animator unlock_anim;

    static float score_timer = 0f;

    void Start () {
        score_text_addition = score_text_addition_input;
        score_text_addition.text = "";
    }

	void Update () {
        if (score_timer > 0f){
            score_text_addition.gameObject.SetActive(true);
            score_timer -= Time.deltaTime;
        }
        else {
            score_text_addition.gameObject.SetActive(false);
        }

        if (score >= 500f && data_manager.hasGreenShip == false){
            unlock_anim.SetTrigger("unlock");
            data_manager.hasGreenShip = true;
            data_manager.save_user_data();
        }

        score += Time.deltaTime;
        score_text.text = Mathf.Floor(score).ToString();
	}

    public static void set_addition (string label) {
        score_text_addition.text = label;
        score_timer = 1.5f;
    }

}
