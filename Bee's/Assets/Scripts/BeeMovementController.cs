using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovementController : MonoBehaviour {

    private Transform _tf;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveHorizontal(float x)
    {
        Debug.Log(x);
    }

    public void MoveVertical(float y)
    {

    }
}
