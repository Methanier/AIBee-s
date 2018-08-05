using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSensor : Sensor
{

    private Transform _tf;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
    }

    private void Update()
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
        if(modality.GetType() == typeof(VisionModality))
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
        //See's Object
        Debug.Log("Sees Player");
    }
}
