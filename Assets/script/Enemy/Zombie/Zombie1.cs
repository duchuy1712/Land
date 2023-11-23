using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    [Header("stat")]
    private Vector2 velocity;
    public Rigidbody2D rb;
    public float speed = 2;
    private float _speed;
    private float _range;

    [Header("knockback")]
    public float knockbackX;
    public float knockbackY;
    public float StunCountdown;
    private float KBcountdown;
    private bool KnockFromRight;
    [Header("Wallcheck")]
    public float range;
    public LayerMask layer;

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        _speed = speed;
        _range = range;
        Vector3 direction = PlayerController.Instance.transform.position - this.transform.position;
        if (direction.x < 0)
        {
            _speed = -_speed;
            _range = -_range;
        }
        else
            return;
    }
    private void Update()
    {
        if (!WallCheck())
        {
            _speed = -_speed;
            _range = -_range;
        }
        if (_speed > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
            transform.eulerAngles = Vector3.up * 180;
    }
    private bool WallCheck()
    {
        RaycastHit2D WallHit = Physics2D.Raycast(rb.position, Vector2.right, _range, layer);
        return WallHit.collider == null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position,new Vector3(rb.position.x + _range, rb.position.y));
    }
    private void FixedUpdate()
    {
        if (KBcountdown > 0)
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(knockbackX, knockbackY);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(-knockbackX, knockbackY);
            }
            KBcountdown -= Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(_speed, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {

            KBcountdown = StunCountdown;
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                KnockFromRight = false;
            }
            else if (collision.gameObject.transform.position.x < transform.position.x)
            {
                KnockFromRight = true;
            }
        }
    }

}