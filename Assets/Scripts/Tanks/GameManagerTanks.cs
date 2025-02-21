using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTanks : MonoBehaviour
{
    // Zona variables globales
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;

    [SerializeField]
    private EnemyManager _enemyManager;

    // GameOverPanel

    public void GameOver()
    {
        
        // Activamos el panel de Game Over
        _panelGameOver.SetActive(true);

        // Desactivamos el componente EnemyManager
        _enemyManager.enabled = false;

    }
    
    // Método para reiniciar la escena
    public void LoadSceneLevel()
    {
        SceneManager.LoadScene(0);

    }
}
