using UnityEngine;
using UnityEngine.UI;

public class ScoreManager  : MonoBehaviour
{
    private int pontos = 0; 
    public SpriteRenderer spriteRenderer; 
    public Sprite[] sprites; 
    
    public int AddPoint()
    {
        if (pontos < 7)
        {
            spriteRenderer.sprite = sprites[pontos]; // Altera o sprite com base na pontuação
            pontos++;
        } 
        return pontos;
    }
    
}
