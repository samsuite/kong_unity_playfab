using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using PlayFab;
using PlayFab.ClientModels;

public class register_manager : MonoBehaviour {

    public InputField username_text;
    public InputField password_text;
    public InputField confirm_password_text;
    public InputField email_text;
    public Button register_button;
    public string next_scene_name;

    void Awake (){
        register_button.onClick.AddListener(delegate { register(); });
        data_manager.on_data_loaded += data_loaded;
    }

	
	void register (){
        if (password_text.text == confirm_password_text.text){
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
		    request.Username = username_text.text;
		    request.Password = password_text.text;
            request.Email = email_text.text;
		    request.TitleId = PlayFabData.TitleId;
		    PlayFabClientAPI.RegisterPlayFabUser(request,register_successful,register_failed);
        }
    }
    void register_successful(RegisterPlayFabUserResult result){
        print ("success!!");
		PlayFabData.AuthKey = result.SessionTicket;
        data_manager.username = username_text.text;
        login_after_register();
	}
	void register_failed(PlayFabError error){
		print ("failure!!");
	}


    void login_after_register (){
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
		request.Username = username_text.text;
		request.Password = password_text.text;
		request.TitleId = PlayFabData.TitleId;
		PlayFabClientAPI.LoginWithPlayFab(request,login_after_register_successful,login_after_register_failed);
    }
    void login_after_register_successful(LoginResult result){
        print ("success!!");
		PlayFabData.AuthKey = result.SessionTicket;
        data_manager.username = username_text.text;
        data_manager.get_user_data();
	}
	void login_after_register_failed(PlayFabError error){
		print ("failure!!");
	}


    void data_loaded(){
        Application.LoadLevel(next_scene_name);
    }
}


