using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform weaponHandler;

    public float bulletForce = 20f;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }


    void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, weaponHandler.rotation);
        Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
