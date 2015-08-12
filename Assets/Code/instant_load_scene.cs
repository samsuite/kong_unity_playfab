using UnityEngine;
using System.Collections;

public class instant_load_scene : MonoBehaviour {

    public string scene_name;

	void Start () {
	    Application.LoadLevel(scene_name);
	}
}
