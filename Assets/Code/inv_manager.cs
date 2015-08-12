using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using PlayFab;
using PlayFab.ClientModels;

public class inv_manager : MonoBehaviour {

    public Button orange_button;
    public Button green_button;
    public Button back_button;
    public GameObject locked;
    public string menu_scene_name;
    public GameObject c_orange;
    public GameObject c_green;

    void Awake (){
        orange_button.onClick.AddListener(delegate { select_orange(); });
        green_button.onClick.AddListener(delegate { select_green(); });
        back_button.onClick.AddListener(delegate { back(); });
    }

    void Start (){

        if (data_manager.hasGreenShip){
            locked.SetActive(false);
            green_button.gameObject.SetActive(true);
        }
        else {
            locked.SetActive(true);
            green_button.gameObject.SetActive(false);
        }

        if (data_manager.shipColor == "orange"){
            c_orange.SetActive(true);
            c_green.SetActive(false);
        }
        else {
            c_orange.SetActive(false);
            c_green.SetActive(true);
        }
    }
	
	void select_green (){
        data_manager.shipColor = "green";
        c_orange.SetActive(false);
        c_green.SetActive(true);
        data_manager.save_user_data();
    }
    void select_orange (){
        data_manager.shipColor = "orange";
        c_orange.SetActive(true);
        c_green.SetActive(false);
        data_manager.save_user_data();
    }
    void back (){
        Application.LoadLevel(menu_scene_name);
    }
}


