using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSensor : Sensor
{

    private Transform _tf;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
        UpdateSensorPosition();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSensorPosition();	
	}

    void UpdateSensorPosition()
    {
        _position = _tf.position;
        _orientation = _tf.forward;
    }

    public override bool DetectsModality(Modality modality)
    {
        if(modality.GetType() == typeof(SoundModality))
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    public override void Notify(Signal signal)
    {
        //Heard Player
        Debug.Log("PlayerHeard");
    }
}
