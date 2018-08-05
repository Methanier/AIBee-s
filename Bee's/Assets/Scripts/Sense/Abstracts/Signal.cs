using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Signal
{

    [SerializeField]
    protected float _strength;
    protected Vector3 _position;
    [SerializeField]
    protected Modality _modality;

    public float Strength { get { return _strength; } }
    public Vector3 Postion { get { return _position; } set { _position = value; } }
    abstract public Modality GetModality { get; }

    
}
