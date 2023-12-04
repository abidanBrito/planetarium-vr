using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receptor : MonoBehaviour
{
    public Transform player;
    void Update(){
        Debug.Log("Player " + player.transform.position);
    }
    
    public void OnPointerEnter(){
        Debug.Log("Detecto algo");
    }

    public void OnPointerExit(){
        Debug.Log("No detecto nada");
    }

    public void OnPointerClick(Vector3 posSuelo){
        Debug.Log("posicion a la que se desplaza el jugador " + posSuelo);
        player.position = new Vector3(posSuelo.x, player.position.y, posSuelo.z);
    }
}
