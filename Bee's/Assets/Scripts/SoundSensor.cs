using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensor : Sensor {

    private void Awake()
    {
        _position = GetComponent<Transform>().position;
        _orientation = GetComponent<Transform>().forward;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override bool DetectsModality(Modality modality)
    {
        Debug.Log("Detects Modality - Sound Sensor");
        return true;
    }

    public override void Notify(Signal signal)
    {
        Debug.Log("Notify");
    }
}
