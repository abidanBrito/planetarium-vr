using UnityEngine;
using System.Collections.Generic;

public class ObjetoSpawner : MonoBehaviour
{
    public List<GameObject> listaDeObjetosPrefabs; // Asigna tus prefabs de objetos aquí en el Inspector
    public Transform objetoDeReferencia; // Asigna el objeto de referencia aquí en el Inspector
    public float radioDeSpawn = 5.0f; // Define el radio alrededor del objeto de referencia para spawnear
    public float tiempoDeSpawn = 2.0f; // Intervalo de tiempo entre cada spawn en segundos

    private void Start()
    {
        // Comienza a invocar la función GenerarObjeto repetidamente cada 'tiempoDeSpawn' segundos
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
        Instantiate(objetoPrefabAleatorio, posicionAleatoria, Quaternion.identity);
    }
}