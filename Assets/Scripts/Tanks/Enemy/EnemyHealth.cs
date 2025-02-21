using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Zona de variables globales
    [Header("Health")]
    // Vida m�xima del tanque
    [SerializeField]
    private float _maxHealth;
    // Vida actual
    [SerializeField]
    private float _currentHealth;
    // Da�o que me hacen las balas enemigas
    [SerializeField]
    private float _damageEnemyshell;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    // Awake
    private void Awake()
    {

        // Inicializaci�n de la vida del tanque
        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

        // Reseteamos las explosiones
        _bigExplosion.Stop();
        _smallExplosion.Stop();


    }
    private void OnTriggerEnter(Collider infoAccess)
    {

        if (infoAccess.CompareTag("TankShell"))
        {
            // Ejecutamos la animaci�n de la explosi�n
            _smallExplosion.Play();

            // Descontamos de la vida actual el coste del impacto
            _currentHealth -= _damageEnemyshell;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if (_currentHealth <= 0.0f)
            {
                Death();
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Death()
    {

        // Debemos extraer la c�mara del objeto
        Camera.main.transform.SetParent(null);

        // Ejecutamos la animaci�n de la explosi�n
        _bigExplosion.Play();

        // Destruimos el tanque
        Destroy(gameObject, 1.0f);

    }
}
