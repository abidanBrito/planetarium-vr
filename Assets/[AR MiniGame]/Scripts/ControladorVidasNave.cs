using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVidasNave : MonoBehaviour
{
    public int vidas = 5;  // Número inicial de vidas

    void Start()
    {
  
  
    }

    void Update()
    {
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("entra Colision");

        if (collision.gameObject.CompareTag("Asteroide"))
        {
            GameController.Instance.PlayerManager.TakeALifeAsteroid();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Planeta"))
        {
              GameController.Instance.PlayerManager.TakeALifePlanet();
              Destroy(collision.gameObject);
        }

        if (vidas <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}
