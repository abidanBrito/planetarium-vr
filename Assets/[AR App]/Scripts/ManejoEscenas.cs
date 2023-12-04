using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManejoEscenas : MonoBehaviour
{
    
    public void CambiarEscenaManejo()
    {
        SceneManager.LoadScene("Movimiento");
    }

    public void CambiarEscenaMain()
    {
    GameController.Instance.AudioManager.PauseBackgroundMusic(); //PARA PAUSARLO    
    SceneManager.LoadScene("Main");
    }

    public void CambiarEscenaMiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }



    public void CambiarEscenaMenu()
    {
        SceneManager.LoadScene("PrueVuforia");
    }

}
