using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subweapon : Bullet
{
    public Rigidbody2D rb2d;
    private Vector2 direction;
    public Vector2 basedirec;
    private void OnEnable()
    {
        direction = basedirec;
        rb2d.gravityScale = 0;
        if (PlayerController.Instance.transform.eulerAngles == Vector3.zero)
        {
            direction = new Vector2(direction.x, direction.y);
        }
        else if (PlayerController.Instance.transform.eulerAngles == Vector3.up * 180)
        {
            direction = new Vector2(-direction.x, direction.y);
        }
    }
    private void Update()
    {
        transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
        }
    }
    public override void Setup(Vector2 dir)
    {
        base.Setup(dir);
        dir = direction;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Candle"))
        {
            gameObject.SetActive(false);
        }
    }
}
