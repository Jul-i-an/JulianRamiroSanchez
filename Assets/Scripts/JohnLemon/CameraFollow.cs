using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Variables globales
    public Transform Target;
    [Header("Vectors")]
    // Velocidad de seguimiento de la c�mara
    [SerializeField]
    private float _smooting;
    // Distancia entre la c�mara y el player
    [SerializeField]
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    private void LateUpdate()
    {

        // Posici�n a la que queremos mover la c�mara
        Vector3 desiredPosition = Target.position + _offset;

        // Movemos la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smooting * Time.deltaTime);  

    }
}
