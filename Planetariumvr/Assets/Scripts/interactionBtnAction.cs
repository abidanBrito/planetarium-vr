using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class interactionBtnAction : MonoBehaviour
{
    public UnityEvent myEventClick;
    public Button button;
    Color currentColor;
    public Sprite imageHover;
    public Sprite imageDefault;
    public Canvas canvas;

    public void OnPointerEnter() {
        button.GetComponent<Image>().sprite = imageHover;
    }

    public void OnPointerExit() {
        button.GetComponent<Image>().sprite = imageDefault;
    }

    public void OnPointerClick()
    {
        myEventClick.Invoke();
    }

    public void changeToInteractionScene(){
        if(SceneManager.GetActiveScene().name != "HelloCardboard"){
            SceneManager.LoadScene("HelloCardboard");
        } else {
            canvas.enabled = false;
        }
    }
}