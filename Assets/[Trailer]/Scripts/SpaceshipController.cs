using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [SerializeField]
    private float flySpeed = 25.0f;

    [SerializeField]
    private float yawAmount = 50.0f;
    private float yaw = 0.0f;

    [SerializeField]
    private float cursorSensitivity = 2.0f;

    void Update()
    {
        // Mover hacia adelante
        transform.position += transform.forward * Time.deltaTime * flySpeed;

        // Obtener entrada de teclado
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        // Control de yaw, pitch y roll
        yaw += xInput * yawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 10, Mathf.Abs(yInput)) * -Mathf.Sign(yInput);
        float roll = Mathf.Lerp(0, 20, Mathf.Abs(xInput)) * -Mathf.Sign(xInput);

        // Aplicar rotación
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw +
            Vector3.right * pitch +
            Vector3.forward * roll);

        // Control de rotación del cursor
        float cursorInputX = Input.GetAxis("Mouse X");
        float cursorInputY = Input.GetAxis("Mouse Y");

        yaw += cursorInputX * cursorSensitivity * Time.deltaTime;

        // Aplicar la rotación en función del cursor
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw +
            Vector3.right * pitch +
            Vector3.forward * roll);
    }
}
