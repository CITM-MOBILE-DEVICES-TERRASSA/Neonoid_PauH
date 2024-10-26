using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Cargar la escena en el índice 1 (Nivel 1)
        SceneManager.LoadScene(1);
    }
}
