using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InputController : MonoBehaviour
{

    [Header("Input Names")]
    [Tooltip("Name of x axis (Left and right movement) in input settings")]
    [SerializeField]
    private string _xAxisName;

    [Tooltip("Name of y axis (Forward and back movement) in input settings")]
    [SerializeField]
    private string _yAxisName;

    [Tooltip("Name of x axis for Mouse (Left/Right movment) Input in settings")]
    [SerializeField]
    private string _mouseXAxisName;

    [Tooltip("Name of y axis for Mouse (Up/Down movement) Input in settings")]
    [SerializeField]
    private string _mouseYAxisName;

    [Tooltip("Name of free look button in input settings")]
    [SerializeField]
    private string _freeLookButtonName;

    [Tooltip("Name of sprint button in input settings")]
    [SerializeField]
    private string _sprintButtonName;

    [Tooltip("Name of interact button in input settings")]
    [SerializeField]
    private string _interactButtonName;

    [Tooltip("Name of stealth button")]
    [SerializeField]
    private string _stealthButtonName;

    [Tooltip("Name of Pause button in input settings")]
    [SerializeField]
    private string _pauseButtonName;

    [Tooltip("Cincemachine Freelook Camera following the player")]
    [SerializeField]
    private CinemachineFreeLook _freeLookCamera;

    private MovementController _movementController;

    //Floats to hold valuse of axis input for mouse or keyboard input
    private float _xAxis;
    private float _yAxis;

    private void Awake()
    {
        _movementController = GetComponent<MovementController>();
    }


    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
            
        if (!GameState.State.IsPaused)
        {
                
            if(_freeLookCamera.m_YAxis.m_InputAxisName == null)
            {
                _freeLookCamera.m_YAxis.m_InputAxisName = _mouseYAxisName;
            }
            CheckInput();
        }
        else
        {
            _freeLookCamera.m_YAxis.m_InputAxisName = null;
        }
    }

    //Checks for user Input
    void CheckInput()
    {
        //Sends the keyboard Horizontal and Vertical movement axis to the Movement Controller
        _movementController.MoveHorizontal(Input.GetAxis(_xAxisName));
        _movementController.MoveVertical(Input.GetAxis(_yAxisName));


        if (Input.GetButton(_sprintButtonName))
        {
            _movementController.IsSprinting = true;
        }
        else
        {
            _movementController.IsSprinting = false;
        }

            
        if (Input.GetButton(_freeLookButtonName))
        {
            _freeLookCamera.m_XAxis.m_InputAxisName = _mouseXAxisName;
            _freeLookCamera.m_RecenterToTargetHeading.m_enabled = false;
        }
        else
        {
            _freeLookCamera.m_XAxis.m_InputAxisName = null;
            _freeLookCamera.m_RecenterToTargetHeading.m_enabled = true;
            _xAxis = Input.GetAxis(_mouseXAxisName);
            _movementController.RotateEntity(_xAxis);
        }           

        
        if (Input.GetButtonDown(_pauseButtonName))
        {
            if(GameState.State.IsPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                GameState.State.IsPaused = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Confined;
                //MainMenuManager.MenuManager.OpenMenu(MainMenuManager.MenuManager.MenuIndex("PauseMenu"));
                GameState.State.IsPaused = true;
            }
            
        }

        /*
        if(Input.GetButtonDown(_interactButtonName))
        {
            //pickup
        }*/


        if(Input.GetButtonDown(_stealthButtonName))
        {
            if(_movementController.IsStealth)
            {
                Debug.Log("Leaveing Stealth");
                _movementController.IsStealth = false;
            }
            else
            {
                if (!_movementController.IsMoving)
                {
                    Debug.Log("Stealthing");
                    _movementController.IsStealth = true;
                }
            }
        }
    }
}
