using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    Image scoreImage;
    public Sprite[] scoreSprites;
    private Vector3 scaleChange;

    void Start()
    {
        scoreImage = GetComponent<Image>();
        scaleChange = new Vector3(1.2f, 0.66f, 0.66f);
    }

    void Update()
    {
        if(GameController.Instance.Points >= 100 && GameController.Instance.Points < 150){
            Color colorActual = scoreImage.color;
            colorActual.a = 1;
            scoreImage.color = colorActual;

            scoreImage.sprite = scoreSprites[0];
        } else if (GameController.Instance.Points >= 150 && GameController.Instance.Points < 200){
            scoreImage.sprite = scoreSprites[1];
        }
        else if(GameController.Instance.Points >= 200){
            gameObject.transform.localScale = scaleChange;
            scoreImage.sprite = scoreSprites[2];

        }
        
    }
}
