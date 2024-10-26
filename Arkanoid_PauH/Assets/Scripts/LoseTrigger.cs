using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.vidas--; // Disminuye las vidas en 1
        Debug.Log("Vidas restantes: " + GameManager.Instance.vidas);

        if (GameManager.Instance.vidas > 0)
        {
            // Cargar la escena en el �ndice 1 (Nivel 1)
            SceneManager.LoadScene(1);
        }
        else
        {
            // Cargar la escena en el �ndice 3 (Game Over)
            SceneManager.LoadScene(3);
        }
    }
}