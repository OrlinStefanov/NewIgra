using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [Header("Collisoin elemnts")]
    private GameObject enemy;
    private GameObject bullet;

    void Start()
    {
        enemy = GameObject.Find("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        bullet = GameObject.Find("bullet(Clone)");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(bullet);

       // Destroy(enemy, 3);
    }
}