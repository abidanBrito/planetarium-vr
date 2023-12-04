using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private uint lives;
    public uint Lives { get { return lives; } private set { lives = value; } }
    
    [SerializeField] private uint bullets;
    public uint Bullets { get { return bullets; } private set { bullets = value; } }
    private uint initialBullets;
    public AudioClip clipGameOver;

    private void Start()
    {
        initialBullets = bullets;
    }

        public void TakeALifeAsteroid()
    {
        if (Lives > 0)
        {
         Debug.Log("¡Colisión con Asteroide! Vidas restantes: " + Lives);

            Lives -= 1;
        }
         if(Lives==0){
            GameOver();
        }
    }

        public void TakeALifePlanet()
    {
        if (Lives > 0)
        {
         Debug.Log("¡Colisión con Planeta! Vidas restantes: " + Lives);

            Lives -= 3;
        }

        
        if(Lives==0){
            GameOver();
        }

    }

    public void WasteABullet()
    {
        if (Bullets > 0)
        {
            Bullets -= 1;
        }
    }

    public void GameOver(){

        Debug.Log("Game Over");
        GameController.Instance.AudioManager.PlaySoundEffect(clipGameOver,1);


    }


    public void ReloadGun()
    {
        Bullets = initialBullets;
    }
}
