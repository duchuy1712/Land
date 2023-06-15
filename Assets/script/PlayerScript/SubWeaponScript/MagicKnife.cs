using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKnife : Bullet
{
    public Rigidbody2D rb2d;
    private Vector2 direction;
    private void OnEnable()
    {
        rb2d.gravityScale = 0;
        if(PlayerController.Instance.transform.eulerAngles == Vector3.zero)
        {
            direction = new Vector2(1f, 1f);
        }
        else if(PlayerController.Instance.transform.eulerAngles == Vector3.up * 180)
        {
            direction = new Vector2(-1f, 1f);
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
    public override void Setup(int _damage, Vector2 dir)
    {
        base.Setup(_damage, dir);
        dir = direction;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
