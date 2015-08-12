using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class login_text : MonoBehaviour {

    Text text_box;

    void Start () {
	    text_box = GetComponent<Text>();
        text_box.text = "LOGGED IN AS " + data_manager.username;
	}
}
