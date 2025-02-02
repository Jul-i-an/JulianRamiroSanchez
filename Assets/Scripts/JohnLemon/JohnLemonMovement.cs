using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemonMovement : MonoBehaviour
{
    // Variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    // Se guarda la direción del movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rb;
    private Animator _anim;
    private float _horizontal, 
                  _vertical;

    private AudioSource _audioSource;

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void OnAnimatorMove()
    {

        _rb.MovePosition(transform.position + (_direction * _anim.deltaPosition.magnitude));

    }

    private void FixedUpdate()
    {

        Rotation();

    }

    // Update is called once per frame
    void Update()
    {

        InputPlayer();
        IsAnimate();
        AudioSteps();

    }

    private void InputPlayer() 
    {
        //Teclas A y D, así como de las flechas <>
        _horizontal = Input.GetAxis("Horizontal");

        //Teclas W y S, así como de las flechas /\ \/>
        _vertical = Input.GetAxis("Vertical");

        //Vector3.forward, Vector2.right, Vector3.left... new Vector3(x, y, z)
        _direction = new Vector3(_vertical, 0.0f, -_horizontal);

        //Normalizar _direction
        _direction.Normalize();

    }

    private void IsAnimate()
    {

        if (_horizontal != 0.0f || _vertical != 0.0f)
        {

            _anim.SetBool("IsWalking", true);

        }
        else
        {

            _anim.SetBool("IsWalking", false);

        }

    }

    private void Rotation() 
    {

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);  
        _rb.MoveRotation(rotation);

    }

    private void AudioSteps() 
    { 
    
        if (_horizontal != 0.0f || _vertical != 0.0f) 
        { 
            if (_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }
        
        }
        else
        {
            _audioSource.Stop();
        }

    
    }
}
