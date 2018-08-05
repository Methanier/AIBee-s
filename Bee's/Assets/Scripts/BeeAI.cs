using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EBeeType
{
    Worker,
    Soldier,
    Queen,
}

public class BeeAI : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private GameObject _movementBounds;
    [SerializeField]
    private EBeeType _beeType;
    [SerializeField]
    private Vector3 _testDestination;
    [SerializeField]
    private Vector3 _testDestination2;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.T))
        {
            _navMeshAgent.SetDestination(_testDestination);
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            _navMeshAgent.SetDestination(_testDestination2);
        }
	}
}
