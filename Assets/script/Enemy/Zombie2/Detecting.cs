using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    public Transform center;
    public float Range;
    public LayerMask player;
    public bool checking()
    {
        Collider2D hit = Physics2D.OverlapCircle(center.position, Range, player);
        if (hit != null)
            return true;
        else
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(center.position, Range);
    }
}

    