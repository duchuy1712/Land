using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie1Controller : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;
    public float speed = 2;
    /*public float minX = -10;
    public float maxX = 10;*/
    public Transform minX;
    public Transform maxX;
    public float disCheck = .75f;

    [Header("knockback")]
    public float knockbackX;
    public float knockbackY;
    public float StunCountdown;
    private float KBcountdown;
    private bool KnockFromRight;


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right * speed, disCheck, LayerMask.GetMask("Obstacles"));
        if (hit.collider != null)
            speed = -speed;
        if (speed > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
            transform.eulerAngles = Vector3.up * 180;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + new Vector2(disCheck * speed / Mathf.Abs(speed), 0));
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
            Vector2 pos = rb.position;
            if (pos.x >= maxX.position.x || pos.x <= minX.position.x)
                speed = -speed;
            pos.x += speed * Time.fixedDeltaTime;
            pos.x = Mathf.Clamp(pos.x, minX.position.x, maxX.position.x);
            rb.MovePosition(pos);
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