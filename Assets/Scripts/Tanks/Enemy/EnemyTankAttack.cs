using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankAttack : MonoBehaviour
{

    // Variables globales
    [Header("Time")]
    [SerializeField]
    private float _timer;

    [SerializeField]
    private float _timeBetweenAttacks;

    private bool _isAttack;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab;

    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private float _factorLaunchForce;

    [Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;

    [SerializeField]
    private float _distance;

    // Awake
    private void Awake()
    {

        _isAttack = false;

    }

    // FixUpdate
    private void FixedUpdate()
    {
        if (_isAttack)
        {
            _isAttack = false;
            Launch();
        }
    }

    // Update is called once per frame
    void Update()
    {

        CountTimer();

    }

    private void CountTimer()
    {

        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        _timer += Time.deltaTime;

        if(Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("PlayerTank") && _timer >= _timeBetweenAttacks)
            {

                _timer = 0.0f;
                _isAttack = true;
                // Se obtiene la distancia entre el tanque player y el enemigo
                _distance = _hit.distance;

            }

        }

    }
    
    private void Launch()
    {
        // Factor correción de la fuerza con la que sale la bala de cañon
        float launchForceFinal = _launchForce * _distance * _factorLaunchForce;
        Rigidbody cloneShellPrefab = Instantiate(_shellEnemyPrefab, _posShell.position, _posShell.rotation);
        cloneShellPrefab.velocity = _posShell.forward * launchForceFinal;


    }

}
