using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        // Cargar la escena en el índice 1 (Nivel 1)
        SceneManager.LoadScene(1);
        GameManager.Instance.blocksLeft = GameObject.FindGameObjectsWithTag("Block").Length; // Disminuye las vidas en 1
    }
}
