using UnityEngine;
using System.Collections;

public class audio_manager : MonoBehaviour {

    static AudioSource sound_source;
    public AudioClip explosion_input;
    public static AudioClip explosion;

	void Start () {
        explosion = explosion_input;
	    sound_source = gameObject.GetComponent<AudioSource>();
	}

    public static void explode () {
        sound_source.clip = explosion;
        sound_source.Play();
    }
}
