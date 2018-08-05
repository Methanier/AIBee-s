using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundSignal : Signal
{
    [SerializeField]
    private SoundModality _soundModality;

    public override Modality GetModality
    {
        get
        {
            return _soundModality;
        }
    }
}
