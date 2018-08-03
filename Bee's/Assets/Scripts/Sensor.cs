using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sensor : MonoBehaviour
{
    [SerializeField]
    protected Vector3 _position;
    [SerializeField]
    protected Vector3 _orientation;
    [SerializeField]
    protected float _threshold;

    public Vector3 Position { get { return _position; } }
    public Vector3 Oreientation {  get { return _orientation; } }
    public float Threshold { get { return _threshold; } }

    public abstract bool DetectsModality(Modality modality);
    public abstract void Notify(Signal signal);
}
