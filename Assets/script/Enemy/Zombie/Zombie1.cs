using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;
    public float speed = 2;

    [Header("knockback")]
    public float knockbackX;
    public float knockbackY;
    public float StunCountdown;
    private float KBcountdown;
    private bool KnockFromRight;
    [Header("Wallcheck")]
    public float range;
    public LayerMask layer;

    private void OnEnable()
    {
        Vector3 direction = PlayerController.Instance.transform.position - this.transform.position;
        if (direction.x < 0)
        {
            speed = -speed;
            range = -range;
        }
        else
            return;
    }
    private void Update()
    {
        if (!WallCheck())
        {
            range = -range;
            speed = -speed;
        }
        if (speed > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
            transform.eulerAngles = Vector3.up * 180;
    }
    private bool WallCheck()
    {
        RaycastHit2D WallHit = Physics2D.Raycast(rb.position, Vector2.right, range, layer);
        return WallHit.collider == null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position,new Vector3(rb.position.x + range, rb.position.y));
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
            rb.velocity = new Vector2(speed, rb.velocity.y);
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