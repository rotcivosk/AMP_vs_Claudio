

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    [SerializeField] int maxScore = 7;
    public ScoreManager scoreManagerPlayerTwo;
    private int player2Health;
    public GameObject victoryScreen;
    private bool gameFinalized = false;
    public ScoreManager scoreManagerPlayerOne;
    private int player1Health;

    public Image imageComponent;
    public Sprite[] sprites;


    public void UpdateScore(bool isPlayerOneScore){

        if (isPlayerOneScore){
            player1Health = scoreManagerPlayerTwo.AddPoint();
            if (player1Health == maxScore)
            {

                victoryScreen.SetActive(true);
                gameFinalized = true;
                Time.timeScale = 0;
                imageComponent.sprite = sprites[0];
            }

        }
        else{
            player2Health = scoreManagerPlayerOne.AddPoint();
            if (player2Health == maxScore)
            {
                victoryScreen.SetActive(true);
                gameFinalized = true;
                Time.timeScale = 0;
                imageComponent.sprite = sprites[1];
            }
        }


    }

    public void ReloadScene(){

        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        gameFinalized = false;
    }
    
    public void Update()
    {
        if (gameFinalized)
        {
            if (Input.GetKey(KeyCode.Space))
                {
                ReloadScene();
            }
        }

    }


}


