using UnityEngine;
using System.Collections;

public class spin_object : MonoBehaviour {
    
    public Vector3 spin_amount;

	void Start () {
	
	}
	
	void Update () {
	    transform.localEulerAngles += spin_amount*Time.deltaTime;
	}
}
