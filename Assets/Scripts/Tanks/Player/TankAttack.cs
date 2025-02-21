using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    // Zona de variables globales
    [Header("Bala")]
    // Referencia al prefabricado de la tabla
    [SerializeField]
    private Rigidbody _shellPrefab;

    // Referencia al "gameObject" vacío que representa la posición de salida
    [SerializeField]
    private Transform _posShell;

    // Fuerza con la que sale la bala
    [SerializeField]
    private float _launchForce;

    //Referencia al componente AudioSource que lleva el objeto "_postShell"
    [SerializeField]
    private AudioSource _audioSource;



    // Update is called once per frame
    void Update()
    {
        
        InputPlayer();

    }

    private void InputPlayer()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Launch();
        }

    }

    private void Launch()
    {

        // instanciamos la bala
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        // Reproducimos el sonido de lanzamiento
        _audioSource.Play();

        // Creamos la bala y la lanzamos
        cloneShellPrefab.velocity = _posShell.forward * _launchForce;

    }
}
