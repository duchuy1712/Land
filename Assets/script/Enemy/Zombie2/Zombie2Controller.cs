using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2Controller : Singleton<Zombie2Controller>
{
    public Transform shootingPoint;
    public float damage;
    public float fireRate;
    private float _curTime;
    public Vector2 dir;
    private bool IsRight;
    public Detecting Detecting;
    public bool isShooting { get; private set; }

    public Transform target;

    private void Facing()
    {
        Vector3 direction = target.position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
            IsRight = true;
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = Vector3.up * 180;
            IsRight = false;
        }
    }
    private void Update()
    {
        Facing();
        _curTime += Time.deltaTime;
        if (_curTime >= fireRate)
        {
            if(Detecting.checking())
                isShooting = true;
        }
        else
        {
            isShooting = false;
        }
    }
    public void EndAttack()
    {
        _curTime = 0;
    }
    public void Shoot()
    {   
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool("Stick");
        if(IsRight == true)
            obj.GetComponent<FireBullet>().Setup(damage,dir);
        else
            obj.GetComponent<FireBullet>().Setup(damage,new Vector2( -dir.x, dir.y));
        obj.transform.position = shootingPoint.position;
        obj.SetActive(true);

    }
}
