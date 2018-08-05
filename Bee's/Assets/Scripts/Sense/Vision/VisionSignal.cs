using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisionSignal : Signal
{

    [SerializeField]
    private MovementController _movementController;
    [SerializeField]
    private VisionModality _visionModality;    

    public override Modality GetModality
    {
        get
        {
            return _visionModality;
        }
    }
}
