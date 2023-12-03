using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntructionBtnAction : MonoBehaviour
{
    public UnityEvent myEventClick;
    public Sprite imageHover;
    public Sprite imageDefault;
    public Button button;

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

    public void showInstructionPage(){
        Debug.Log("Mostrar instrucciones");
    }
}