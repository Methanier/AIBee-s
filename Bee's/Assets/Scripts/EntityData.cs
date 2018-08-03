using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Entity", menuName = "Entity", order = 0)]
public class EntityData : ScriptableObject
{
    [Header("Survival Stats")]
    [Tooltip("Entities Health")]
    [SerializeField]
    private float _health = 100.0f;

    [Header("Mass")]
    [Tooltip("Mass of Entity in kilograms")]
    [SerializeField]
    private float _mass = 43.0f;                

    [Header("Movement")]
    [Tooltip("Movement speed of Entity left and right")]
    [SerializeField]
    private float _baseMoveSpeed = 1;

    [Tooltip("Percentage speed increases for sprinting 1 is no increase 2 is double speed")]
    [Range(1, 2)]
    [SerializeField]
    private float _sprintModifier;

    [Tooltip("How long it takes to transition between walk and sprinting animation")]
    [SerializeField]
    private float _sprintTransitionSpeed;

    [Tooltip("How quickly this entity can turn")]
    [SerializeField]
    private float _rotationSpeed = 300.0f;

    [Tooltip("How high this entity can jump")]
    [SerializeField]
    private float _jumpForce = 180.0f;

    [Tooltip("Layers entity can jump from")]
    [SerializeField]
    private LayerMask _groundLayers;


    //Properties
    public float Health { get { return _health; } }
    public float Mass { get { return _mass; } }
    public float MoveSpeed { get { return _baseMoveSpeed; } }
    public float SprintModifier { get { return _sprintModifier; } }
    public float SprintTransitionSpeed { get { return _sprintTransitionSpeed; } }
    public float RotationSpeed { get { return _rotationSpeed; } }
    public float JumpForce { get { return _jumpForce; } }
    public LayerMask GroundLayers { get { return _groundLayers; } }
}