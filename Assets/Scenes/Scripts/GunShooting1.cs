using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform bulletRespwnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 35;
    private int bulletCount = 0;
    private double coolDown = 5;
    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && bulletCount < 15 && reloading == false)
        {
            bulletCount++;
            var bullet = Instantiate(bulletPrefab, bulletRespwnPoint.position, bulletRespwnPoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bulletRespwnPoint.forward * bulletSpeed;
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            reloading = true;
            coolDown = 3.5;
        }

        if (reloading == true)
        {
            coolDown -= 0.005;

            if (coolDown <= 0)
            {
                ResetBullets();
            }
        }

        if (bulletCount >= 15)
        {
            coolDown -= 0.005;

            if (coolDown <= 0)
            {
                ResetBullets();
            }
        }
    }

    private void ResetBullets()
    {
        bulletCount = 0;
        coolDown = 5;
        reloading = false;
    }
}
