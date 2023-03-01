using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // The bullet prefab to spawn
    [SerializeField] private Transform bulletSpawn; // The position to spawn the bullet
    [SerializeField] private float bulletSpeed = 50f; // The speed at which the bullet travels
    [SerializeField] private float fireRate = 0.2f; // The time delay between shots
    private float nextFireTime = 0f; // The next time when the player can fire

    private void Update()
    {
        if(Mouse.current.leftButton.wasPressedThisFrame && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = bulletSpawn.forward * bulletSpeed;

        Destroy(bullet, 1);
    }
}
