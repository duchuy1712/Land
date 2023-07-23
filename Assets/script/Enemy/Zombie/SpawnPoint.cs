using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public float cooldownTime;
    private float current_time;

    private void Update()
    {
        if (current_time <= 0)
        {
            Spawn("Hit");
            Spawn("Zombie");
            current_time = cooldownTime;
        }
        else
            current_time -= Time.deltaTime;
    }

    public void Spawn(string name)
    {
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool(name);
        obj.transform.position = transform.position;
        obj.SetActive(true);
    }
}