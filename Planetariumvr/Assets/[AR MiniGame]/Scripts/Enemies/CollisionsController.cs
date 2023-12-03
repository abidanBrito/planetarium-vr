using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsController : MonoBehaviour
{
    public int maximasColisiones;
    int colisionesActuales = 1;

    // Partículas de explosión
    public ParticleSystem explosionParticles;
    
    public uint puntosSumados;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            // Colisión con una BALA
            if (colisionesActuales == maximasColisiones)
            {

                Destroy(gameObject); // Se destruye a sí mismo
                GameController.Instance.AddPoints(puntosSumados);
            }
            else
            {
                colisionesActuales++;
                // Instanciar partículas de explosión
                Instantiate(explosionParticles, transform.position, Quaternion.identity);

            }
        }
    }
}
