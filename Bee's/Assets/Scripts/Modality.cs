using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Modality : MonoBehaviour{

    [SerializeField]
    protected float _maxRange;
    [SerializeField]
    protected float _attenuation;
    [SerializeField]
    protected float _inverseTransmissionSpeed;

    public float MaxRange { get { return _maxRange; } }
    public float Attenuation { get { return _attenuation; } }
    public float InverseTransmissionSpeed { get { return _inverseTransmissionSpeed; } }

    public abstract bool ExtraChecks(Signal inSignal, Sensor inSensor);
}
