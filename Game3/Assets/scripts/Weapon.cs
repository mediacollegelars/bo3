using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float bulletvelocity = 30f;
    public float bulletPrefabLifeTime = 3f;
     

    // Start is called before the first frame update
    void Update()
    {
        //leftmouseclick
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            FireWeapon(); 
        }
    }

    // Update is called once per frame

    
    private void FireWeapon()
    {
        //instantie
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        //shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.forward.normalized * bulletvelocity, ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime)); 
       
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
