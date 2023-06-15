using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;

    public float speed = 2;
    /*public float minX = -10;
    public float maxX = 10;*/
    public Transform minX;
    public Transform maxX;
    public float disCheck = .75f;


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
        Vector2 pos = rb.position;
        if (pos.x == maxX.position.x || pos.x == minX.position.x) 
            speed = -speed;
        pos.x += speed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, minX.position.x, maxX.position.x);
        rb.MovePosition(pos);
    }
}   