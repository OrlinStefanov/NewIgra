using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamreShaking : MonoBehaviour
{
    //delete after
    public Transform enemy;
    public Transform Player;
    public float speed = 4f;
    public Rigidbody rb;
    //delete here


    public GameObject Enemy;//delete after it's for collison

    //don't delete 
    public GameObject GetHit;
    public Image health;

    void Start()
    {

    }

    void Update()
    {
        if (Enemy)
        {
            enemyMove();
            GetHurtCoolDown();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Enemy)
        {
            GetHurt();
        }
    }

    private void GetHurt()
    {
        var color = GetHit.GetComponent<Image>().color;
        color.a = 0.8f;

        GetHit.GetComponent<Image>().color = color;
        health.fillAmount -= 0.1f;
    }

    private void GetHurtCoolDown()
    {
        if (GetHit != null)
        {
            if (GetHit.GetComponent<Image>().color.a > 0)
            {
                var color = GetHit.GetComponent<Image>().color;
                color.a -= 0.01f;

                GetHit.GetComponent<Image>().color = color;
            }
        }
    }

    //delete after
    private void enemyMove()
    {
        Vector3 playerPosition = new Vector3(Player.transform.position.x, 1, Player.transform.position.z);

        Vector3 pos = Vector3.MoveTowards(enemy.transform.position, playerPosition, speed * Time.fixedDeltaTime);

        rb.MovePosition(pos);
        enemy.LookAt(Player);
    }
}
