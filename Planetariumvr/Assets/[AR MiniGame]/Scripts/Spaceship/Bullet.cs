using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float life = 3f;

   

   

    void Awake()
    {
        Destroy(gameObject, life);
    }



    void OnTriggerEnter(Collider collision)
    {
        Destroy(gameObject); //Se destruye a si mismo

    }
}
