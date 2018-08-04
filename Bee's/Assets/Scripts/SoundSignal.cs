using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSignal : Signal {

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
