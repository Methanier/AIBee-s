using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

struct Notification
{
    public float time;
    public Sensor sensor;
    public Signal signal;
}

public class RegionalSenseManager : MonoBehaviour {

    private List<Sensor> _sensors;
    private List<Notification> notificationQueue;

    void AddSignal(Signal signal)
    {
        //List<Sensor> validSensors = new List<Sensor>();
        float distance;
        float intensity;
        float time;

        foreach(Sensor sens in _sensors)
        {
            // Testing Phase

            //Check Modailty First

            if(!sens.DetectsModality(signal.GetModality))
            {
                continue;
            }

            //Find the distance and check range
            distance = (signal.Postion - sens.Position).magnitude;
            if(signal.GetModality.MaxRange <  distance)
            {
                continue;
            }

            //find the intensity and check threshold
            intensity = signal.Strength * Mathf.Pow(signal.GetModality.Attenuation, distance);

            if (intensity < sens.Threshold)
            {
                continue;
            }

            //additional Modality specific checks
            if(!signal.GetModality.ExtraChecks(signal, sens))
            {
                continue;
            }

            time = Time.time + (distance * signal.GetModality.InverseTransmissionSpeed);

            Notification notify = new Notification();
            notify.time = time;
            notify.sensor = sens;
            notify.signal = signal;
            notificationQueue.Add(notify);
        }

        SendSignals();
    }

    void SendSignals()
    {
        //Notification Phase

        float currentTime = Time.time;

        while(notificationQueue.Count > 0)
        { 
            //Looks are first element in list
            Notification nextNotify = notificationQueue[0];

            if (nextNotify.time <= currentTime)
            {
                nextNotify.sensor.Notify(nextNotify.signal);
                notificationQueue.RemoveAt(0);                      //Removes first element in list
                notificationQueue.Sort(CompareNotifcationTimes);    //Sorts list by notification time
            }
        }
    }

    private static int CompareNotifcationTimes(Notification notify1, Notification notify2)
    {
        return notify1.time.CompareTo(notify2.time);
    }
}
