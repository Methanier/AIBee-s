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

    public static RegionalSenseManager SenseManager;

    [SerializeField]
    private List<Sensor> _sensors;
    private List<Notification> notificationQueue;

    private void Awake()
    {
        if(SenseManager == null)
        {
            SenseManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        notificationQueue = new List<Notification>();
    }

    public void AddSignal(Signal signal)
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
            Vector3 signalToSenseVector = signal.Postion - sens.Position;
            distance = signalToSenseVector.magnitude;
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

        if (notificationQueue.Count > 0)
            StartCoroutine("SendSignals");
    }

    IEnumerator SendSignals()
    {
        //Notification Phase

        float currentTime;

        while(notificationQueue.Count > 0)
        {
            currentTime = Time.time;
            //Looks are first element in list
            Notification nextNotify = notificationQueue[0];

            if (nextNotify.time <= currentTime)
            {
                nextNotify.sensor.Notify(nextNotify.signal);
                notificationQueue.RemoveAt(0);                      //Removes first element in list
                notificationQueue.Sort(CompareNotifcationTimes);    //Sorts list by notification time
            }
            yield return null;
        }
    }

    private static int CompareNotifcationTimes(Notification notify1, Notification notify2)
    {
        return notify1.time.CompareTo(notify2.time);
    }
}
