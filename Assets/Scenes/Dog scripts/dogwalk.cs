using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogwalk : MonoBehaviour
{
    // Start is called before the first frame update
    // The target marker.
    public Transform target;
    public Animator animator;
    // Angular rotationSpeed in radians per sec.
    public float rotationSpeed = 1.0f, speed = 10, multby = 20, distance = 10;
    Vector3 newDirection, checkDirection;
    bool rotate = true;

    void Start()
    {
        speed = speed/100;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = new Vector3(target.position.x, transform.position.y, target.position.z) - transform.position;

        // The step size is equal to rotationSpeed times frame time.
        float singleStep = rotationSpeed * Time.deltaTime;

        checkDirection = newDirection;

        // Rotate the forward vector towards the target direction by one step
        newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        if(!rotate && Vector3.Distance(target.position, transform.position) > distance)
        {  
            transform.Translate(new Vector3(0, 0, speed));
        }
        if(Mathf.Floor(newDirection.x * multby) == Mathf.Floor(checkDirection.x * multby) 
        && Mathf.Floor(newDirection.y * multby) == Mathf.Floor(checkDirection.y * multby))
        {
            rotate = false;
            if(Mathf.Floor(Vector3.Distance(target.position, transform.position)) > distance)
            {
                animator.SetFloat("Speed", 1);
            }else{
                animator.SetFloat("Speed", 0);
            }
        }else{
            rotate = true;
        }
        if(Vector3.Distance(target.position, transform.position) <= distance)
        {
            animator.SetFloat("Speed", 0);
        }
    }
}
