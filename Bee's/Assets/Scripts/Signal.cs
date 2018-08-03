using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Signal : MonoBehaviour{

    [SerializeField]
    protected float _strength;
    [SerializeField]
    protected Vector3 _position;
    [SerializeField]
    protected Modality _modality;

    public float Strength { get { return _strength; } }
    public Vector3 Postion { get { return _position; } }
    public Modality GetModality { get { return _modality; } }
}
