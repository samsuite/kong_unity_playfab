using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using PlayFab;
using PlayFab.ClientModels;

public class menu_manager : MonoBehaviour {

    public Button play_button;
    public Button ships_button;
    public Button options_button;
    public string play_scene_name;
    public string inv_scene_name;
    public string opt_scene_name;

    void Awake (){
        play_button.onClick.AddListener(delegate { play(); });
        ships_button.onClick.AddListener(delegate { ships(); });
        options_button.onClick.AddListener(delegate { options(); });
    }
	
	void play (){
        Application.LoadLevel(play_scene_name);
    }
    void ships (){
        Application.LoadLevel(inv_scene_name);
    }
    void options (){
        //Application.LoadLevel(opt_scene_name);
    }
}


