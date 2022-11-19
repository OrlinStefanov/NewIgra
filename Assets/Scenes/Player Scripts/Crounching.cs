using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crounching : MonoBehaviour
{
    [Header("Crounching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    public Rigidbody rb;

    public KeyCode crouchKey = KeyCode.LeftShift;

    // Start is called before the first frame update
    void Start()
    {
        startYScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Crouching();
    }

    private void Crouching()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
}
