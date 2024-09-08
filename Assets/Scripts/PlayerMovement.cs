using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isPlayerOne;
    public string playerName;
    public float playerSpeed;
  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isPressingUp = false;
        bool isPressingDown = false;
        
        if (isPlayerOne) {
            isPressingUp = Input.GetKey(KeyCode.W);
            isPressingDown = Input.GetKey(KeyCode.S);
        } else {
            isPressingUp = Input.GetKey(KeyCode.UpArrow);
            isPressingDown = Input.GetKey(KeyCode.DownArrow);
        }

        if (isPressingUp) {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);

        }

        if (isPressingDown) {
            transform.Translate(Vector3.down * playerSpeed * Time.deltaTime);
        }
    }
}
