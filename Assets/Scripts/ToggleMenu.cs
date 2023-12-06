using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menuMagnet;
    public GameObject canvas;

    void Update()
    {
        if (Input.GetButtonDown("B"))
        {
            ToggleMenuVisibility();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            ToggleMenuVisibility();
        }

        if (!canvas.activeSelf)
        {
            gameObject.transform.position = menuMagnet.transform.position;
            gameObject.transform.rotation = menuMagnet.transform.rotation;
        }
    }

    private void ToggleMenuVisibility()
    {
        Debug.Log("Muestra/oculta menu");
        canvas.SetActive(!canvas.activeSelf);
    }
}