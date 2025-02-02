using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Zona de variables globales 
    [Header("Images")]
    [SerializeField]
    private UnityEngine.UI.Image _caughtImage;
    [SerializeField]
    private UnityEngine.UI.Image _wonImage;

    [Header("Fade")]
    // Duracción del "fade" de la imagen
    [SerializeField]
    private float _fadeDuration;

    // Tiempo de permanencia de la imagen en pantalla
    [SerializeField]
    private float _displayImageDuration;

    //Contador de tiempo
    private float _timer;

    // Detectar si el usuario ha conseguido salir
    public bool IsPlayerAtExit;

    // Detectar si el usuario ha sido pillado
    public bool IsPlayerCaught;

    // Detectar si el usuario ha reseteado el nivel
    private bool _isRestartLevel;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _caughtClip;
    [SerializeField]
    private AudioClip _wonClip;

    private AudioSource _audioSource;

    private void Awake()
    {

        _audioSource = GetComponent<AudioSource>();
        _wonImage.gameObject.SetActive(false);
        _caughtImage.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlayerAtExit)
        {
            Won();
        }
        else if (IsPlayerCaught) 
        { 
            Caught();
        }
        
    }

    private void Won() 
    { 
    
        _audioSource.clip = _wonClip;
        if (_audioSource.isPlaying == false) 
        { 
        
            _audioSource.Play();
        
        }

        _timer += Time.deltaTime;

        _wonImage.gameObject.SetActive(true);
        
        // Aumentamos el canal alfa de la imagen poco a poco
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer / _fadeDuration);

        // La imagen se muestre durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration) 
        {

            Debug.Log("He ganado");

        }

    }

    private void Caught()
    {

        _audioSource.clip = _caughtClip;
        if (_audioSource.isPlaying == false)
        {

            _audioSource.Play();

        }

        _timer += Time.deltaTime;

        _caughtImage.gameObject.SetActive(true);

        // Aumentamos el canal alfa de la imagen poco a poco
        _caughtImage.color = new Color(_caughtImage.color.r, _caughtImage.color.g, _caughtImage.color.b, _timer / _fadeDuration);

        // La imagen se muestre durante un tiempo
        if (_timer > _fadeDuration + _displayImageDuration)
        {

            Debug.Log("He perdido");
            SceneManager.LoadScene("JuanitoLimones");

        }

    }

    public void reloadGame() 
    {

        SceneManager.LoadScene("JuanitoLimones");

    }

    private void OnTriggerEnter(Collider infoCollider) 
    {

        if (infoCollider.CompareTag("JohnLemon")) 
        {

            IsPlayerAtExit = true;

        }

    }
}
