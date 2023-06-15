using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Camera selfCamera;
    public Transform campos1;
    public Transform campos2;
    private void Awake()
    {
        selfCamera = GetComponent<Camera>();
    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        //cameraPosition.x = Mathf.Max(cameraPosition.x, player.position.x);
        cameraPosition.x = Mathf.Clamp(player.position.x, campos1.position.x, campos2.position.x);
        transform.position = cameraPosition;
    }
}
