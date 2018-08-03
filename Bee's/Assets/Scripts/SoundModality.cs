using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundModality : Modality {

    public override bool ExtraChecks(Signal inSignal, Sensor inSensor)
    {
        return true;
    }
}
