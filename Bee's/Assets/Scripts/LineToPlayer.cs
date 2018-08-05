using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineToPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform _tf;
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private Vector3 _thisVector3;
    [SerializeField]
    private Vector3 _playerVector3;

    [SerializeField]
    private bool bUseVector3 = false;

    private void OnDrawGizmos()
    {
        
        if (!bUseVector3)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_tf.position, _player.transform.position);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_thisVector3, _playerVector3);            
        }
    }
}
