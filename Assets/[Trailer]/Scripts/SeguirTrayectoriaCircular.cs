using UnityEngine;

public class SeguirTrayectoriaCircular : MonoBehaviour
{
    public Transform objetoReferencia; // El objeto alrededor del cual girará
    public float radio = 5.0f; // Radio de la trayectoria circular
    public float velocidadRotacion = 45.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Asegúrate de que el objeto de referencia no sea nulo
        if (objetoReferencia == null)
        {
            Debug.LogError("Objeto de referencia no asignado. Por favor, asigna un objeto de referencia en el Inspector.");
            return;
        }

        // Calcula la posición en la trayectoria circular
        float angulo = Time.time * velocidadRotacion; // Ángulo basado en el tiempo
        float x = objetoReferencia.position.x + radio * Mathf.Cos(angulo * Mathf.Deg2Rad);
        float y = objetoReferencia.position.y;
        float z = objetoReferencia.position.z + radio * Mathf.Sin(angulo * Mathf.Deg2Rad);

        // Actualiza la posición del objeto
        transform.position = new Vector3(x, y, z);
    }
}