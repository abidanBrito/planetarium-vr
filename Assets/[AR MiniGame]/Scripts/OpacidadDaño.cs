using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpacidadDaño : MonoBehaviour
{
    public Image damage;

    private float r;
    private float g;
    private float b;
    private float a;

    private int semaforo;
    void Start()
    {
        r = damage.color.r;
        g = damage.color.g;
        b = damage.color.b;
        a = damage.color.a;
        Debug.Log("Valor de Opacidad: " + a);
    }


void Update(){

if(semaforo ==1){
Debug.Log("entra update:" +a);
a-= 0.01f;

ChangeColor();
}

if(a <0){
    a=0;
}



}
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("entra Colision script daño");

        if  (collision.gameObject.CompareTag("Asteroide") || collision.gameObject.CompareTag("Planeta"))
        {
            // Incrementar la opacidad
            a += 5f;
            a = Mathf.Clamp01(a); // Asegurarse de que a esté en el rango [0, 1]
            semaforo=1;
            // Actualizar el color
            ChangeColor();
            Destroy(collision.gameObject);
        }else{
            semaforo=0;
        }
    }
    private void ChangeColor()
    {
        Color c = new Color(r, g, b, a);
        damage.color = c;
    }
}
