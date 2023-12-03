using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;  // El objeto alrededor del cual la cámara orbitará.
    public float orbitSpeed = 10.0f;  // Velocidad de rotación de la cámara.

    private Vector3 offset;

    void Start()
    {
        if (target == null)
        {
            // Si no se ha asignado un objetivo, utiliza la cámara principal como objetivo.
            target = Camera.main.transform;
        }

        // Calcula el offset inicial desde la cámara al objetivo.
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (target == null)
            return;

        // Calcula el ángulo de rotación basado en la entrada del usuario o el tiempo.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float orbitAngle = orbitSpeed * Time.deltaTime;

        // Aplica la rotación alrededor del objetivo.
        transform.RotateAround(target.position, Vector3.up, orbitAngle * horizontalInput);
        transform.RotateAround(target.position, transform.right, orbitAngle * verticalInput);

        // Mantiene la cámara mirando al objetivo.
        transform.LookAt(target.position);
    }
}
