using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitBtnAction : MonoBehaviour
{
    // Start is called before the first frame update
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

    public void ExitApp()
{
    #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
    #else
    Application.Quit();
    #endif
}
}
