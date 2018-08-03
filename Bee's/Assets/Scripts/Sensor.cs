using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor
{
    protected Vector3 _position;
    protected Quaternion _orientation;
    protected float _threshold;

    public Vector3 Position { get { return _position; } }
    public Quaternion Oreientation {  get { return _orientation; } }
    public float Threshold { get { return _threshold; } }

    public abstract bool DetectsModality(Modality modality);
    public abstract void Notify(Signal signal);
}
