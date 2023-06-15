using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSController : Singleton<VSController>
{
    [SerializeField] private Transform ShootingPoint;
    [SerializeField] private Transform center;
    public float range;
    public LayerMask player;
    public int damage;
    public Vector2 dir;
    public float firerate;
    private float currentTime;
    private bool isRight;
    public bool isShooting { get; private set; }

    [SerializeField] private Transform target;
    private void Facing()
    {
        Vector3 direction = target.position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
            isRight = true;
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
            isRight = false;
        }
    }
    private void Update()
    {
        Facing();
        currentTime += Time.deltaTime;
        if (currentTime >= firerate)
        {
            if (checking())
                isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }
    public void EndAttack()
    {
        currentTime = 0;
    }
    private void Shoot()
    {
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool("LazerBullet");
        if (isRight == true)
            obj.GetComponent<LazerBullet>().Setup(damage, dir);
        else
            obj.GetComponent<LazerBullet>().Setup(damage, new Vector2(-dir.x, dir.y));
        obj.transform.position = ShootingPoint.position;
        obj.SetActive(true);
    }
    private bool checking()
    {
        Collider2D hit = Physics2D.OverlapCircle(center.position, range, player);
        if (hit != null)
            return true;
        else
            return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position, range);
    }

}
