using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    // Zona de variables Globales
    [Header("Instantiate")]
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform[] _posRotEnemy;
    [SerializeField]
    private float _timeBetweeEnemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemies", _timeBetweeEnemies, _timeBetweeEnemies);
    }


    private void CreateEnemies()
    {
        
        int n = Random.Range(0, _posRotEnemy.Length);   

        Instantiate(_enemyPrefab, _posRotEnemy[n].position, _posRotEnemy[n].rotation);

    }
}
