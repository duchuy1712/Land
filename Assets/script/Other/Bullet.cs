using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    protected virtual void Movement()
    {
    }
    public virtual void Setup(Vector2 dir)
    {
    }
    public virtual void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
}
