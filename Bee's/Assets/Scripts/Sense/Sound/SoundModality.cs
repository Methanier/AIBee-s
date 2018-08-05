using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundModality : Modality
{

    public override bool ExtraChecks(Signal inSignal, Sensor inSensor)
    {
        return true;
    }

    public override void ResetAttenuation()
    {
        Attenuation = _defaultAttenuation;
    }
}
