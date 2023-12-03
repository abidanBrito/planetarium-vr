using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrailerBtnAction : MonoBehaviour
{
    public UnityEvent myEventClick;
    public Button button;
    Color currentColor;
    public Sprite imageHover;
    public Sprite imageDefault;
    public Canvas canvas;

    public void OnPointerEnter() {
        button.GetComponent<Image>().sprite = imageHover;
        /* = button.GetComponent<Image>().color;
        currentColor.a = 0.8f;
        button.GetComponent<Image>().color = currentColor;*/
    }

    public void OnPointerExit() {
button.GetComponent<Image>().sprite = imageDefault;
    }

        public void OnPointerClick()
    {
        myEventClick.Invoke();
    }

    public void changeToTrailerScene(){
        if(SceneManager.GetActiveScene().name != "Trailer360"){
            SceneManager.LoadScene("Trailer360");
        } else {
            canvas.enabled = false;
        }
    }
}
