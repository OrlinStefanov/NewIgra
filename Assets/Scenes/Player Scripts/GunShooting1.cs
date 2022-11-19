using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform bulletRespwnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 35;
    private int bulletCount = 15;
    private double coolDown = 5;
    private bool reloading = false;
    public Animation gunAnimate;

    public Text ammo;
    public Text ammoAlarm;
    private int bulletCollect = 85;
    private readonly int bulletNum = 15;

    // Start is called before the first frame update
    void Start()
    {
        gunAnimate = GetComponent<Animation>();
        gunAnimate.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        if (bulletCollect <= 0 && bulletCount <= 0)
        {
            bulletCollect = 0;
            bulletCount = 0;

            ammo.text = bulletCount.ToString() + "/" + bulletCollect + " Ammo";

            var color = ammoAlarm.GetComponent<Text>().color;
            color.a = 255f;

            ammoAlarm.color = color;
        } else
        {
            ammo.text = bulletCount.ToString() + "/" + bulletCollect + " Ammo";

            if (Input.GetMouseButtonUp(0) && bulletCount > 0 && reloading == false && !gunAnimate.IsPlaying("gunrelaodsA"))
            {
                bulletCount--;
                var bullet = Instantiate(bulletPrefab, bulletRespwnPoint.position, bulletRespwnPoint.rotation);

                bullet.GetComponent<Rigidbody>().velocity = bulletRespwnPoint.forward * bulletSpeed;


                if (!gunAnimate.IsPlaying("AimShooting"))
                {
                    gunAnimate.Play("gunrelod");
                }
            }

            if (Input.GetMouseButtonDown(1) && reloading == false && !gunAnimate.IsPlaying("gunrelaodsA"))
            {
                gunAnimate.Play("AimShooting");
            }

            if (Input.GetMouseButtonUp(1) && reloading == false && !gunAnimate.IsPlaying("gunrelaodsA"))
            {
                gunAnimate.Stop();
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                reloading = true;
                coolDown = 1.5;
            }

            if (reloading == true)
            {
                coolDown -= 5 * Time.deltaTime;
                gunAnimate.Play("gunrelaodsA");

                if (coolDown <= 0)
                {
                    ResetBullets();
                }
            }

            if (bulletCount == 0)
            {
                coolDown -= 5 * Time.deltaTime;
                reloading = true;

                if (coolDown <= 0)
                {
                    ResetBullets();
                }
            }
        }
    }

    private void ResetBullets()
    {
        bulletCollect -= bulletNum - bulletCount;

        if (bulletCollect <= 0)
        {
            bulletCount = bulletCollect;
        } else
        {
            bulletCount = 15;
        }

        coolDown = 4;
        reloading = false;
    }
}
