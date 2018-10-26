using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.One)) {
            print("Button Pressed Hammer");
        }
	}
}
