using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Modality
{

    [SerializeField]
    protected float _maxRange;
    [SerializeField]
    protected float _defaultAttenuation;
    [SerializeField]
    protected float _currentAttenuation;
    [SerializeField]
    protected float _inverseTransmissionSpeed;

    public float MaxRange { get { return _maxRange; } }
    public float Attenuation { get { return _currentAttenuation; } set { _currentAttenuation = value; } }
    public float InverseTransmissionSpeed { get { return _inverseTransmissionSpeed; } }

    public abstract bool ExtraChecks(Signal inSignal, Sensor inSensor);
    public abstract void ResetAttenuation();
}
