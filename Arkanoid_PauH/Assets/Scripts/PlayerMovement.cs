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
        // Solo mueve el jugador si el botón izquierdo del ratón está presionado
        if (Input.GetMouseButton(0))
        {
            // Obtener la posición del ratón en unidades de mundo en el eje X
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));

            // Restringir la posición X dentro de los límites
            float clampedX = Mathf.Clamp(mousePosition.x, -bounds, bounds);

            // Actualizar la posición del jugador en el eje X
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }
}