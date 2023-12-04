using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD_Controller : MonoBehaviour
{
    // Referencia al objeto Texto
    public GameObject miCanvas; // Asigna tu Canvas desde el Inspector

    public Image[] magazine;
    private uint numPlayerItems = 0;
    private uint initialPlayerItems = 0;
    public string selectedItem = "";

    void Start(){
        if(selectedItem == "Bullets"){
            initialPlayerItems = GameController.Instance.PlayerManager.Bullets;
        } else if(selectedItem == "Lives"){
            initialPlayerItems = GameController.Instance.PlayerManager.Lives;
        }


        miCanvas.SetActive(false);
        

       
    }
    void Update()
    {
        if(selectedItem == "Bullets"){
            numPlayerItems = GameController.Instance.PlayerManager.Bullets;
        } else if(selectedItem == "Lives"){
            numPlayerItems = GameController.Instance.PlayerManager.Lives;
        }
        for(uint i=0;i<numPlayerItems; i++){
            adjustImageOpacity(magazine[i], 1f);
        }
        for(uint i=numPlayerItems;i<initialPlayerItems;i++){
            adjustImageOpacity(magazine[i], 0f);
        }

        if(GameController.Instance.PlayerManager.Lives == 0){
         ActivarODesactivarCanvas();

        }
        if(GameController.Instance.PlayerManager.Lives > 0){
         DesctivarODesactivarCanvas();

        }

         Debug.Log("tu vidas " + GameController.Instance.PlayerManager.Lives);


 
    }

    void adjustImageOpacity(Image image, float opacity){
        Color colorActual = image.color;
        colorActual.a = opacity;
        image.color = colorActual;
    }

      void ActivarODesactivarCanvas()
    {
        if (miCanvas != null)
        {
            // Invertir el estado del Canvas (activar si está desactivado, desactivar si está activado)
            miCanvas.SetActive(true);
            Debug.Log("CANVAS DE DERROTA2");

        }
    }
          void DesctivarODesactivarCanvas()
    {
        if (miCanvas != null)
        {
            // Invertir el estado del Canvas (activar si está desactivado, desactivar si está activado)
            miCanvas.SetActive(false);
            Debug.Log("CANVAS DE REINICIO");

        }
    }
}
