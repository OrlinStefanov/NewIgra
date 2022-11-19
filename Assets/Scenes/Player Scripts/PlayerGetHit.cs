using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamreShaking : MonoBehaviour
{
    public GameObject Enemy;

    public GameObject GetHit;
    public Image health;

    void Start()
    {

    }

    void Update()
    {
        GetHurtCoolDown();
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
}
