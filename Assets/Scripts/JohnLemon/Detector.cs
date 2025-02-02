using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    // Zona de variables globales
    public GameManager GameManagerScript;

    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("JohnLemon")) 
        {

            Debug.Log("Te he pilladoooo");
            GameManagerScript.IsPlayerCaught = true;
        }       
        
    }
}
