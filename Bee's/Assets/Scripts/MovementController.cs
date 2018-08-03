using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Tooltip("Data Object for this Entity")]
    [SerializeField]
    private EntityData _thisData;

    private Animator _animator;
    private Transform _tf;
    private CapsuleCollider _col;
    private Rigidbody _rb;

    private float _currentMoveSpeed;
    private float _velocity = 0f;

    public bool IsSprinting { get; set; }
    public bool IsMoving { get; set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _tf = GetComponent<Transform>();
        _col = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
        _rb.mass = _thisData.Mass;
        _currentMoveSpeed = _thisData.MoveSpeed;
        IsSprinting = false;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIsSprinting();
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
            _rb.AddForce(Vector3.up * _thisData.JumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(_col.bounds.center, new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z), _col.radius * 0.9f, _thisData.GroundLayers);
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
}