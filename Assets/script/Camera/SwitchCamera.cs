using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject camera_room;
    [SerializeField] private GameObject Enemy_in_room;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerTag"))
        {
            camera_room.SetActive(true);
            if (Enemy_in_room != null)
                Enemy_in_room.SetActive(true);
            else
                return;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            camera_room.SetActive(false);
            if (Enemy_in_room != null)
                Enemy_in_room.SetActive(false);
            else
                return;
        }
    }
}
