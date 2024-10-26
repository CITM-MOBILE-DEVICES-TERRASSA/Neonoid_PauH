using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float bounds = 4.5f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Solo mueve el jugador si el bot�n izquierdo del rat�n est� presionado
        if (Input.GetMouseButton(0))
        {
            // Obtener la posici�n del rat�n en unidades de mundo en el eje X
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Restringir la posici�n X dentro de los l�mites
            float clampedX = Mathf.Clamp(mousePosition.x, -bounds, bounds);

            // Actualizar la posici�n del jugador en el eje X
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}