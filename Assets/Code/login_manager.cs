using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using PlayFab;
using PlayFab.ClientModels;

public class login_manager : MonoBehaviour {

    public InputField username_text;
    public InputField password_text;
    public Button login_button;
    public string next_scene_name;

    void Awake (){
        login_button.onClick.AddListener(delegate { login(); });
        data_manager.on_data_loaded += data_loaded;
    }
	
	void login (){
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
		request.Username = username_text.text;
		request.Password = password_text.text;
		request.TitleId = PlayFabData.TitleId;
		PlayFabClientAPI.LoginWithPlayFab(request,login_successful,login_failed);
    }
    void login_successful(LoginResult result){
        print ("success!!");
		PlayFabData.AuthKey = result.SessionTicket;
        data_manager.username = username_text.text;
        data_manager.get_user_data();
	}
	void login_failed(PlayFabError error){
		print ("failure!!");
	}



    void data_loaded(){
        Application.LoadLevel(next_scene_name);
    }
}


