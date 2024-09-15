using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] bool isPlayerOne;
    [SerializeField] float playerSpeed = 5f;


    [SerializeField] private float minX = -5f; // Limite mínimo no eixo X
    [SerializeField] private float maxX = 5f;  // Limite máximo no eixo X
  
    private Vector3 moveDirection; // Direção do movimento

    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    // Método responsável por capturar as entradas de movimento
    private void HandleInput()
    {
        float moveVertical = 0f;
        float moveHorizontal = 0f;

        if (isPlayerOne)
        {
            moveVertical = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
            moveHorizontal = Input.GetKey(KeyCode.D) ? 1f : (Input.GetKey(KeyCode.A) ? -1f : 0f);
        }
        else
        {
            moveVertical = Input.GetKey(KeyCode.UpArrow) ? 1f : (Input.GetKey(KeyCode.DownArrow) ? -1f : 0f);
            moveHorizontal = Input.GetKey(KeyCode.RightArrow) ? 1f : (Input.GetKey(KeyCode.LeftArrow) ? -1f : 0f);
        }

        // Atualiza a direção do movimento
        moveDirection = new Vector3(moveHorizontal, moveVertical, 0f).normalized;
    }

    // Método responsável por mover o jogador
    private void MovePlayer()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * playerSpeed * Time.deltaTime);

            // Limita a posição no eixo X após o movimento
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        }
    }
}
