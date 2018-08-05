using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{

    public static GameState State;

    public bool IsPaused { get; set; }

    private void Awake()
    {
        if(State == null)
        {
            State = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
