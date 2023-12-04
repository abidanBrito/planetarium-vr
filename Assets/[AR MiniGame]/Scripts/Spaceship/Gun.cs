using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private float reloadTime = 10f;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private AudioClip clipDisparo;

    void Start()
    {
        StartCoroutine(ReloadGun());
    }

    public void Shoot()
    {
        uint bulletsLeft = GameController.Instance.PlayerManager.Bullets;

        if (bulletsLeft > 0)
        {
            GameController.Instance.AudioManager.PlaySoundEffect(clipDisparo,1);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            GameController.Instance.PlayerManager.WasteABullet();
        }
    }

    IEnumerator ReloadGun()
    {
        while (true)
        {
            yield return new WaitForSeconds(reloadTime);

            if (GameController.Instance.PlayerManager.Bullets == 0)
            {
                GameController.Instance.PlayerManager.ReloadGun();
            }
        }
    }
}
