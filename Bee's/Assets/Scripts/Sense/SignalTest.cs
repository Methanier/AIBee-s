using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalTest : MonoBehaviour
{

    public SoundSignal sound;
    public VisionSignal vision;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.T))
        {
            RegionalSenseManager.SenseManager.AddSignal(vision);
        }
	}
}
