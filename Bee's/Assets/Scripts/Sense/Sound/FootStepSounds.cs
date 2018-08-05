using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{

    private AudioSource _audioSource;
    private Animator _anim;
    private Transform _tf;
    private MovementController _movementController;

    [SerializeField]
    private AudioClip _footStepClip;
    [SerializeField]
    private SoundSignal _walkSignal;
    [SerializeField]
    private SoundSignal _runSignal;

    private void Awake()
    {
        _tf = GetComponent<Transform>();
        _audioSource = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _movementController = GetComponent<MovementController>();


        _audioSource.clip = _footStepClip;
        UpdateSignalPosition();
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(_anim.GetFloat("Horizontal") == 0 && _anim.GetFloat("Vertical") == 0)
        {
            _audioSource.Stop();
        }
	}

    void UpdateSignalPosition()
    {
        _walkSignal.Postion = _tf.position;
        _runSignal.Postion = _tf.position;
    }

    public void PlayFootStep()
    {
        if(_anim.GetFloat("Horizontal") == 0 && _anim.GetFloat("Vertical") == 0)
        {

        }
        else
        {
            _audioSource.Play();
            UpdateSignalPosition();
            if(_movementController.IsSprinting)
            {
                RegionalSenseManager.SenseManager.AddSignal(_runSignal);
            }
            else
            {
                RegionalSenseManager.SenseManager.AddSignal(_walkSignal);
            }
            
        }
        
    }

    public void StopFootStep()
    {
        _audioSource.Stop();
    }
}
