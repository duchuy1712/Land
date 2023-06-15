using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (direction.x < 0)
            transform.eulerAngles = Vector3.up * 180;
    }
}
