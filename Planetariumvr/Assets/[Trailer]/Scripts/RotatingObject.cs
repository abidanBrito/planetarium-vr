using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto en el eje Y a una velocidad constante
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}