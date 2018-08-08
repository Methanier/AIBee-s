using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Tooltip("Data Object for this Entity")]
    [SerializeField]
    private EntityData _thisData;
    [Tooltip("Collider on the left foot")]
    [SerializeField]
    private CapsuleCollider _leftFootCollider;
    [Tooltip("Collider on the right foot")]
    [SerializeField]
    private CapsuleCollider _rightFootCollider;

    private Animator _animator;
    private Transform _tf;
    private Rigidbody _rb;
    private VisionTests _visionController;

    private float _currentMoveSpeed;
    private float _velocity = 0f;

    public bool IsSprinting { get; set; }
    public bool IsMoving { get; set; }
    public bool IsStealth { get; set; }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _tf = GetComponent<Transform>();
        _rb = GetComponentInChildren<Rigidbody>();
        _visionController = GetComponent<VisionTests>();
        _rb.mass = _thisData.Mass;
        _currentMoveSpeed = _thisData.MoveSpeed;
        IsSprinting = false;
        IsMoving = false;
        IsStealth = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsSprinting();
        CheckIsMoving();
        CheckStealthState();
    }

    public void MoveHorizontal(float x)
    {
        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Speed", _currentMoveSpeed);
    }

    public void MoveVertical(float y)
    {
        _animator.SetFloat("Vertical", y);
        _animator.SetFloat("Speed", _currentMoveSpeed);
    }

    public void RotateEntity(float input)
    {
        _tf.Rotate(Vector3.up, input * _thisData.RotationSpeed * Mathf.Deg2Rad);
    }

    public bool RotateTowards(Transform target)
    {
        Vector3 vectorToTarget = target.position - _tf.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);

        if (targetRotation != _tf.rotation)
        {
            _tf.rotation = Quaternion.RotateTowards(_tf.rotation, targetRotation, _thisData.RotationSpeed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RotateTowards(Vector3 target)
    {
        Vector3 vectorToTarget = target - _tf.position;

        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget);

        if (targetRotation != _tf.rotation)
        {
            _tf.rotation = Quaternion.RotateTowards(_tf.rotation, targetRotation, _thisData.RotationSpeed * Time.deltaTime);
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            IsMoving = true;
            _rb.AddForce(Vector3.up * _thisData.JumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        if(_leftFootCollider != null && _rightFootCollider != null)
        {
            if(Physics.CheckCapsule(_leftFootCollider.bounds.center, new Vector3(_leftFootCollider.bounds.center.x, _leftFootCollider.bounds.min.y, _leftFootCollider.bounds.center.z), _leftFootCollider.radius * 0.9f, _thisData.GroundLayers))
            {
                return true;
            }
            else if(Physics.CheckCapsule(_rightFootCollider.bounds.center, new Vector3(_rightFootCollider.bounds.center.x, _rightFootCollider.bounds.min.y, _rightFootCollider.bounds.center.z), _rightFootCollider.radius * 0.9f, _thisData.GroundLayers))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }        
    }

    void CheckIsSprinting()
    {
        if (IsSprinting)
        {
            _currentMoveSpeed = Mathf.SmoothDamp(_currentMoveSpeed, _thisData.MoveSpeed * _thisData.SprintModifier, ref _velocity, _thisData.SprintTransitionSpeed);
        }
        else
        {
            _currentMoveSpeed = Mathf.SmoothDamp(_currentMoveSpeed, _thisData.MoveSpeed, ref _velocity, _thisData.SprintTransitionSpeed);
        }
    }

    void CheckIsMoving()
    {
        if(_animator.GetFloat("Horizontal") == 0 && _animator.GetFloat("Vertical") == 0 && IsGrounded())
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
    }

    void CheckStealthState()
    {
        if(IsStealth)
        {
            if(IsMoving)
            {
                Debug.Log("Leaving Stealth");
                IsStealth = false;
                return;
            }

            _visionController.Vision.GetModality.Attenuation = 0;
        }
        else
        {
            _visionController.Vision.GetModality.ResetAttenuation();
        }
    }
}