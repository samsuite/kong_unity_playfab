using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

using PlayFab;
using PlayFab.ClientModels;


public class data_manager : MonoBehaviour {

    public static bool hasGreenShip = false;
    public static string username = "guest";
    public static string shipColor = "orange";
    public static float highScore = 0f;


    public delegate void data_event_handler();
    public static event data_event_handler on_data_loaded;
    public static event data_event_handler on_data_saved;

    public void Start (){
        PlayFabSettings.TitleId = "BC83";
    }

    ////// GET USER DATA

    public static void get_user_data (){
        GetUserDataRequest request = new GetUserDataRequest();
		PlayFabClientAPI.GetUserData(request,get_user_data_successful,get_user_data_failed);
    }
    static void get_user_data_successful(GetUserDataResult result){

        if (result.Data.ContainsKey("shipColor")){
            shipColor = result.Data["shipColor"].Value;
        }
        if (result.Data.ContainsKey("hasGreenShip")){
            hasGreenShip = (result.Data["hasGreenShip"].Value == "true");
        }
        if (result.Data.ContainsKey("highScore")){
            highScore = float.Parse(result.Data["highScore"].Value);
        }

        save_user_data();
        on_data_loaded();
	}
	static void get_user_data_failed(PlayFabError error){
		print ("failure!! "+ error.ErrorMessage);
	}




    ////// SAVE USER DATA

    public static void save_user_data (){

        Dictionary<string, string> user_data = new Dictionary<string, string>();
		
        user_data.Add("shipColor", shipColor);
        user_data.Add("hasGreenShip", hasGreenShip.ToString().ToLower());
        user_data.Add("highScore", highScore.ToString());

        UpdateUserDataRequest request = new UpdateUserDataRequest();
        request.Data = user_data;
		PlayFabClientAPI.UpdateUserData(request,save_user_data_successful,save_user_data_failed);
    }
    static void save_user_data_successful(UpdateUserDataResult result){
        print ("success!! saved data");
        //on_data_saved();
	}
	static void save_user_data_failed(PlayFabError error){
		print ("failure!! "+ error.ErrorMessage);
	}
}
