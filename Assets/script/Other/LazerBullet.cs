using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBullet : Bullet
{
    public Rigidbody2D rb2d;
    private Vector2 direction;
    private void OnEnable()
    {
        rb2d.gravityScale = 0;
    }
    private void Update()
    {
        transform.position += new Vector3(direction.x, 0,0) * speed * Time.deltaTime;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
    }
    public override void Setup(int _damage, Vector2 dir)
    {
        base.Setup(_damage, dir);
        direction = dir;
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlayerTag"))
        {
            this.gameObject.SetActive(false);
            ResetBullet();
        }
        if(collision.gameObject.CompareTag("PlayerTag"))
        {
            PlayerData.Instance.Get_Damage(damage);
        }
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PlayerTag"))
        {
            this.gameObject.SetActive(false);
            ResetBullet();
        }/*
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            PlayerData.Instance.Get_Damage(damage);
        }*/
    }
}
