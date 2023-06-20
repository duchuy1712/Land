using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] private Camera maincamera;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Collider2D coll;
    [SerializeField] private LayerMask layer;
    [SerializeField] private AttackController AttackController;
    [SerializeField] private PlayerDataManager PlayerStat;

    Vector2 velocity;
    float inputAxis;

    public float JumpForce => (2f * PlayerStat.maxJumpHeight) / (PlayerStat.maxJumpTime /2f);
    public float gravity => (-2f * PlayerStat.maxJumpHeight) / Mathf.Pow(PlayerStat.maxJumpTime / 2f , 2f);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool sliding =>(inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);
    
    private void OnEnable()
    {
        rb2d.isKinematic = false;
        coll.enabled = true;
        velocity = Vector2.zero;
        jumping = false;
    }

    private void OnDisable()
    {
        rb2d.isKinematic = true;
        coll.enabled = false;
        velocity = Vector2.zero;
        jumping = false;
    }
    private void Update()
    {
        moving();
        if (Grounded() && AttackController.groundAttack == false)
            jump();
        if (!platformhit())
            velocity.y = -JumpForce;
        applyGravity();
        AttackController.StartAttack();
        
    }   
    private void FixedUpdate()
    {
        Vector2 position = rb2d.position;
        position += velocity * Time.deltaTime;
        Vector2 left = maincamera.ScreenToWorldPoint(Vector2.zero);
        Vector2 right = maincamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, left.x + 0.5f, right.x - 0.5f);

        rb2d.MovePosition(position);

    }
    //check xem nhân vật có đang trên mặt đất hay không
    public bool Grounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(rb2d.position, coll.bounds.size - new Vector3(0.1f, 0.5f, 0f), 0f, Vector2.down, 0.5f, layer);
        return hit.collider != null;
    }
    // check nếu nhân vật va phải vật cản khi đang nhảy, lập tức rơi xuống
    public bool platformhit()
    {
        RaycastHit2D platformhit = Physics2D.Raycast(rb2d.position, Vector2.up, 1.7f, layer);
        return platformhit.collider == null;
    }
    //lệnh di chuyển
    private void moving()
    {
        if (AttackController.groundAttack == false)
        {
            inputAxis = Input.GetAxis("Horizontal");
            velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * PlayerStat.speed, (PlayerStat.speed * PlayerStat.SliceForce) * Time.deltaTime);
            if (velocity.x > 0)
                transform.eulerAngles = Vector3.zero;
            else if (velocity.x < 0)
                transform.eulerAngles = Vector3.up * 180f;
        }
        else
            velocity.x = 0;
    }
    // nhảy
    private void jump()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0;
        

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = JumpForce;
            jumping = true;
        }
    }
    //tăng trọng lực khi rơi
    private void applyGravity()
    {
        bool falling = velocity.y < 0 || !Input.GetKey(KeyCode.W);

        float multiplier = falling ? 3 : 1;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Hit!");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(rb2d.position, Vector2.up * 1.7f);
    }
    
}
