using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{

    // Zona de variables globales
    [Header("CamaraFollow")]
    // Recuperamos el transform del player
    [SerializeField]
    private Transform _player;

    // Velicidad de movimiento de c�mara (Suavizado)
    [SerializeField]
    private float _smoothing;

    // Distancia entre el player y la c�mara
    [SerializeField]
    private Vector3 _offset;


    // Start is called before the first frame update
    void Start()
    {

        
        _offset = transform.position - _player.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        // La posici�n a la que quiero mover la c�mara
        Vector3 camPosition  = _player.position + _offset;
        transform.position = Vector3.Lerp(transform.position, camPosition, _smoothing * Time.deltaTime);   
        
    }
}
