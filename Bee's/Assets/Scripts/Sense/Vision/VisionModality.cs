using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VisionModality : Modality
{

    [SerializeField]
    private GameObject _thisGameObject;
    [SerializeField]
    private float _fieldOfView;
    [Tooltip("Range player needs to be in for bee to alert soldiers")]
    [SerializeField]
    private float _alertRange;
    

    public override bool ExtraChecks(Signal inSignal, Sensor inSensor)
    {

        Vector3 modifiedPlayerPosition = new Vector3(inSignal.Postion.x, inSignal.Postion.y + 1, inSignal.Postion.z);

        Vector3 vectorFromBee = modifiedPlayerPosition - inSensor.Position;

        float angleFromBee = Vector3.Angle(vectorFromBee, inSensor.Oreientation);

        Ray rayFromBee = new Ray();

        RaycastHit hitInfo;

        rayFromBee.origin = inSensor.Position;
        rayFromBee.direction = vectorFromBee;

        if(Physics.Raycast(rayFromBee, out hitInfo, _maxRange))
        {
            if(hitInfo.collider.gameObject.tag == "Player")
            {
                if(angleFromBee <= (_fieldOfView /2 ))
                {
                    if(hitInfo.distance <= _alertRange)
                    {
                        //TODO:
                        //alert soldiers
                    }
                    return true;
                }
            }
        }
        return false;
    }

    public override void ResetAttenuation()
    {
        Attenuation = _defaultAttenuation;
    }
}
