using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facingver2 : MonoBehaviour
{
    public Transform target;
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
