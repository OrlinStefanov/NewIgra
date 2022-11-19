using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [Header("Collisoin elemnts")]
    private GameObject bullet;
    public float DogLife = 3;

    void Start() { 

    }

    // Update is called once per frame
    void Update()
    {
        bullet = GameObject.Find("bullet (1) Variant(Clone)");
    }

    private void OnCollisionEnter(Collision collision)
    {
        DogLife--;

        Destroy(bullet);

       if (collision.gameObject.name == "dog2-animated" && DogLife == 1)
       {
            Destroy(collision.gameObject);
            Destroy(bullet);
       }
    }
}