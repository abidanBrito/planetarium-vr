using UnityEngine;

public class XRotating : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto en el eje X a una velocidad constante
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
