using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public List<GameObject> listaDeObjetosPrefabs; // Asigna tus prefabs de objetos aquí en el Inspector
    public Transform objetoDeReferencia; // Asigna el objeto de referencia aquí en el Inspector
    public Transform naveTransform; // Asigna el transform de la nave aquí en el Inspector
    public float radioDeSpawn = 5.0f; // Define el radio alrededor del objeto de referencia para spawnear
    public float tiempoDeSpawn = 2.0f; // Intervalo de tiempo entre cada spawn en segundos
    public float velocidadHaciaNave = 5.0f; // La velocidad a la que el objeto se moverá hacia la nave

    private void Start()
    {
        // Comienza a invocar la función GenerarObjeto repetidamente cada 'tiempoDeSpawn' segundos
       

    }
    public void Asteroids()
    {
        InvokeRepeating(nameof(GenerarObjeto), tiempoDeSpawn, tiempoDeSpawn);
    }
      
    void GenerarObjeto()
    {
        // Genera una posición aleatoria dentro del radio alrededor del objeto de referencia
        Vector3 posicionAleatoria = objetoDeReferencia.position + Random.insideUnitSphere * radioDeSpawn;
        posicionAleatoria.y = objetoDeReferencia.position.y; // Mantén la altura igual si solo deseas variar en el plano XZ

        // Selecciona un prefab aleatorio de la lista
        GameObject objetoPrefabAleatorio = listaDeObjetosPrefabs[Random.Range(0, listaDeObjetosPrefabs.Count)];

        // Instancia un nuevo objeto en la posición aleatoria generada
        GameObject nuevoObjeto = Instantiate(objetoPrefabAleatorio, posicionAleatoria, Quaternion.identity);

        // Asegúrate de que el objeto tenga un componente Rigidbody
        Rigidbody rb = nuevoObjeto.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = nuevoObjeto.AddComponent<Rigidbody>();
        }
        rb.useGravity = false; // Desactiva la gravedad si no es necesaria

        // Calcula la dirección hacia la nave
        Vector3 direccionHaciaNave = (naveTransform.position - nuevoObjeto.transform.position).normalized;

        // Aplica la velocidad hacia la dirección de la nave
        rb.velocity = direccionHaciaNave * velocidadHaciaNave;
    }
}
