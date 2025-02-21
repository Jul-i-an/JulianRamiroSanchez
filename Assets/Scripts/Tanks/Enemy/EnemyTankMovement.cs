using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    // Variables globales
    [Header("TankPersecution")]
    [SerializeField]
    private GameObject _player;
    [SerializeField] 
    private NavMeshAgent _agent;

    // Awake
    private void Awake()
    {

        _player = GameObject.FindGameObjectWithTag("PlayerTank");
        _agent = GetComponent<NavMeshAgent>();

    }


    // Update is called once per frame
    void Update()
    {
     
        if (_player == null)
        {

            return;

        }
        GetPlayer();
    }

    private void GetPlayer()
    {

        _agent.SetDestination(_player.transform.position);

    }
}
