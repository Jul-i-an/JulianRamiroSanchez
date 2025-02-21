using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    // Zona de variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal, 
                  _vertical;

    private Rigidbody _rb;


    [Header("Sound")]
    [SerializeField]
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _driveClip;

    private AudioSource _audioSource;

    // Awake
    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Metodo para mover las f�sicas de los objetos de la escena
    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        AudioPlayer();


    }

    private void Start()
    {
        // Damos al Play para que empiece a sonar el audio nada m�s empezar el juego
        _audioSource.Play();
    }

    private void InputsPlayer()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

    
    }
    // M�todo para realizar el movimiento del objeto
    private void Move()
    {
        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);

    }
    // M�todo para realizar el giro del objeto
    private void Turn()
    {
        
        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);
        _rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {
        //Controlamos si el tanque se est� moviendo o en rotaci�n
        if ((_vertical != 0.0f) || (_horizontal != 0.0f))   // El tanque se mueve
        {
            //Si est� en movimiento, verificar si el audio que suena es el que corresponde
            if (_audioSource.clip != _driveClip) 
            { 
                _audioSource.clip = _driveClip;
                _audioSource.Play();    
            }
        }
        else // El tanque esta detenido
        {
            //Si est� parado, verificar si el audio que suena es el que corresponde
            if (_audioSource.clip != _idleClip)
            {
                _audioSource.clip = _idleClip;
                _audioSource.Play();
            }

        }

    }
}
