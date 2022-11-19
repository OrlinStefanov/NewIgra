using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsSpawn : MonoBehaviour
{
    public GameObject DogPerfab;
    public Transform DogPos;
    public int dogCount;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vector = new Vector3(DogPos.position.x, DogPos.position.y, DogPos.position.z);

        for (int i = 0; i < dogCount; i ++)
        {
            vector.x += i * 10;

            dogCount--;

            DogPos.position = vector;

            SpawnDogs();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnDogs()
    {
        var dog = Instantiate(DogPerfab, DogPos.position, DogPos.rotation);

        dog.GetComponent<Rigidbody>();
        dog.GetComponent<BoxCollider>();
        dog.GetComponent <dogwalk>();
    }
}
