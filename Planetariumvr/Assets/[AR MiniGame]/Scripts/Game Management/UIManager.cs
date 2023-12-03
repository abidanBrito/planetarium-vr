using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() => UpdateBullets();

    public void UpdateScore() => scoreText.text = "Score: " +
                                 GameController.Instance.Points.ToString();

    // NOTE(abi): Iván, implementa la lógica de actualizar la barra de balas aquí.
    // Lo suyo sería usar eventos, pero refrescamos la UI en cada fotograma y au.
    public void UpdateBullets()
    {
        
    }
}
