using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int CountDown = 3;
    private float cur_time = 0;
    private void Update()
    {
        cur_time += Time.deltaTime;
        if(cur_time >= CountDown)
        {
            cur_time = 0;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            gameObject.SetActive(false);
        }
    }
}
