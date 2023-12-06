using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CambiarEscenaTrailer : MonoBehaviour
{
    public void changeToTrailerScene()
    {
        if (SceneManager.GetActiveScene().name != "Trailer360")
        {
            SceneManager.LoadScene("Trailer360");
        }
        
        Debug.Log("Botón presionado");
       
    }
}
