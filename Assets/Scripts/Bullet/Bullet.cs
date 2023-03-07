using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; 
    [SerializeField]
    private Transform bulletSpawn; 
    [SerializeField]
    private float bulletSpeed = 35f; 
    [SerializeField]
    private float fireRate = 0.2f; 
    private float nextFireTime = 0f; 
    [SerializeField]
    private GameObject bulletImpactPrefab;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && Time.time > nextFireTime)
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
        Destroy(bullet, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
        }
        GameObject impact = Instantiate(bulletImpactPrefab, collision.GetContact(0).point, Quaternion.identity);
        impact.transform.forward = collision.GetContact(0).normal;

        Destroy(gameObject);
        Destroy(impact, 1f);
    }
}