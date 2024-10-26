using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int vidas = 3;
    public int blocksLeft;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que GameManager persista entre escenas
        }
    }

    void Update()
    {
        blocksLeft = GameObject.FindGameObjectsWithTag("Block").Length;
        Debug.Log("Bloques restantes: " + blocksLeft);

    }

    public void BlockDestroyed()
    {
        blocksLeft--;

        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (blocksLeft <= 0)
        {
            if (currentSceneIndex == 1)
            {
                // Cargar la escena en el índice 2 (Nivel 2)
                SceneManager.LoadScene(2);
            }
            else if (currentSceneIndex == 2)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}