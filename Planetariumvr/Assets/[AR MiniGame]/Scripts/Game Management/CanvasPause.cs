using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : MonoBehaviour
{
    public GameObject canvasPausa;  // Asigna tu canvas de pausa en el Inspector
    public string nombreDeLaSiguienteEscena;  // Nombre de la siguiente escena, configurado en el Inspector
    private bool juegoPausado = false;

    void Update()
    {
        // Pausar o reanudar el juego al presionar la tecla 'P' (puedes cambiar la tecla según tus necesidades)
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }
    }

    public void PausarJuego()
    {
        Time.timeScale = 0f;  // Pausa el tiempo en el juego
        juegoPausado = true;
        canvasPausa.SetActive(true);  // Activa el canvas de pausa
    }

    public void ReanudarJuego()
    {
        Time.timeScale = 1f;  // Reanuda el tiempo en el juego
        juegoPausado = false;
        canvasPausa.SetActive(false);  // Desactiva el canvas de pausa
    }

    public void Continuar()
    {
        ReanudarJuego();  // Reanuda el juego cuando se hace clic en el botón "Continuar"
    }

    public void Salir()
    {
        Time.timeScale = 1f;  // Asegúrate de que el tiempo esté reanudado antes de cargar otra escena
        CargarEscena(nombreDeLaSiguienteEscena);  // Carga la siguiente escena configurada en el Inspector
    }

    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
