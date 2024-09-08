using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D ballRigidbody;
    public float startVelocity;
    public GameController controller;
    public Vector2 posicaoInicial = Vector2.zero;
    public AudioSource audioSource;
    public AudioClip[] clips;
    private int iteradorClips;



    // Start is called before the first frame update
    void Start()
    {
        ResetarPosicaoBola();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "RightBorder")
        {
            Debug.Log("Tocou na Direita");
            controller.UpdateScore(true);
            ResetarPosicaoBola();
            iteradorClips =9;
            audioSource.PlayOneShot(clips[iteradorClips]);




        }    
        if (collision.gameObject.tag == "LeftBorder")
        {
            controller.UpdateScore(false);
            ResetarPosicaoBola();
            Debug.Log("Tocou na Esquerda");
                        iteradorClips =8;
            audioSource.PlayOneShot(clips[iteradorClips]);
        }

        if (collision.gameObject.tag == "Player1")
        {
            iteradorClips = Random.Range(5, 8);
            audioSource.PlayOneShot(clips[iteradorClips]);
        }
        if (collision.gameObject.tag == "Player2")
        {
            iteradorClips = Random.Range(0, 5);
            audioSource.PlayOneShot(clips[iteradorClips]);
        }
    }

    public void ResetarPosicaoBola (){
        ballRigidbody.transform.position = posicaoInicial;
        float playerXDirection = 0;
        float playerYDirection = 0;
        while (playerXDirection == 0){
            playerXDirection = Random.Range(2,-2);
        }
        while (playerYDirection == 0){
            playerYDirection = Random.Range(2,-2);
        }
        ballRigidbody.velocity = new Vector2(playerXDirection * startVelocity, playerYDirection * startVelocity);
    }

}
