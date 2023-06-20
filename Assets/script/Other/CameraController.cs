using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Camera selfCamera;
    public float followSpeed;
    public bool changeroom = false;
    public Vector2 targetPosition;
    public Transform left;
    public Transform right;
    public Transform up;
    public Transform down;
    private float curtime = 0;
    public float delay;
    private void Awake()
    {
        selfCamera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        if (changeroom == false)
        {
            Vector3 cameraPosition = transform.position;
            cameraPosition.x = Mathf.Clamp(player.position.x, left.position.x, right.position.x);
            cameraPosition.y = Mathf.Clamp(player.position.y, down.position.y, up.position.y);
            transform.position = cameraPosition;
        }
        else if((changeroom == true))
        {
            Time.timeScale = 0;
            targetPosition.x = left.position.x;
            if(transform.position.x != left.position.x)
                transform.position = Vector3.Lerp(transform.position,new Vector3(targetPosition.x,targetPosition.y, transform.position.z), followSpeed * Time.fixedDeltaTime);
            curtime += Time.fixedDeltaTime;
            if(curtime >= delay)
            {
                Time.timeScale = 1;
                changeroom = false;
                curtime = 0;
            }
        }
    }
}
