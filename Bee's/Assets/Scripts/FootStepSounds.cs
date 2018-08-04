using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour {

    private AudioSource _audioSource;
    private Animator _anim;
    [SerializeField]
    private AudioClip _footStepClip;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _footStepClip;

        _anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayFootStep()
    {
        Debug.Log(_anim.GetFloat("Horizontal"));
        Debug.Log(_anim.GetFloat("Vertical"));
        if(_anim.GetFloat("Horizontal") == 0 && _anim.GetFloat("Vertical") == 0)
        {

        }
        else
        {
            _audioSource.Play();
        }
        
    }

    public void StopFootStep()
    {
        _audioSource.Stop();
    }
}
