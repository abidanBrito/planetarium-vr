using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menuMagnet;
    bool active = false;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!canvas.isActiveAndEnabled){
            gameObject.transform.position = menuMagnet.transform.position;
            gameObject.transform.rotation = menuMagnet.transform.rotation;
        }
    }
}
