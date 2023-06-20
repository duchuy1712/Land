using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecamerapos : MonoBehaviour
{
    public Transform newLeftPos;
    public Transform newRightPos;
    public Transform newUpPos;
    public Transform newDownPos;
    public CameraController maincamera;
    public GameObject EnemyInRoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            maincamera.left = newLeftPos;
            maincamera.right = newRightPos;
            maincamera.up = newUpPos;
            maincamera.down = newDownPos;
            maincamera.changeroom = true;
            EnemyInRoom.SetActive(true);
        }
    }
}
