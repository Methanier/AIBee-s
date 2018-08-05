using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTests : MonoBehaviour
{

    private Transform _tf;

    [Tooltip("Float in seconds between when vision signals are sent out")]
    [SerializeField]
    private float _timeBetweenVisionCalls;
    [SerializeField]
    private VisionSignal _visionSignal;

    public VisionSignal Vision { get { return _visionSignal; } }

    private void Awake()
    {
        _tf = GetComponent<Transform>();
        UpdateVisionPosition();
    }

    private void Start()
    {
        StartCoroutine("SendVisionSignal");
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateVisionPosition();
	}

    void UpdateVisionPosition()
    {
        _visionSignal.Postion = _tf.position;
    }

    IEnumerator SendVisionSignal()
    {
        while(true)
        {
            RegionalSenseManager.SenseManager.AddSignal(_visionSignal);
            yield return new WaitForSeconds(_timeBetweenVisionCalls);
        }
    }
}
