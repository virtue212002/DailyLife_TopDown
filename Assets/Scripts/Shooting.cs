using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrfabs;

    public float bulletForce = 20f;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrfabs, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.AddForce(firePoint.position * bulletForce, ForceMode2D.Impulse);
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
