using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    public Rigidbody2D rb2d;
    private Vector2 direction;
    private void OnEnable()
    {
        rb2d.gravityScale = 0;
        if (PlayerController.Instance.transform.eulerAngles == Vector3.zero)
        {
            direction = new Vector2(1f, 0f);
        }
        else if (PlayerController.Instance.transform.eulerAngles == Vector3.up * 180)
        {
            direction = new Vector2(-1f, 0f);
        }
    }
    private void Update()
    {
        transform.position += new Vector3(direction.x, 0, 0) * speed * Time.deltaTime;
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
}
