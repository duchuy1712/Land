using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int MaxHP;
    public int CurrentHP { get; private set; }
    public int Damage;
    public bool isHurt { get; private set; }
    public float duration;
    private float cur_time;

    private void Awake()
    {
        CurrentHP = MaxHP;
    }

    private void Update()
    {
        if(isHurt)
        {
            cur_time += Time.deltaTime;
            if(cur_time >= duration)
            {
                isHurt = false;
                cur_time = 0;
            }
        }
    }

    public void Get_Damage(int _amount)
    {
        CurrentHP -= _amount;
        if (CurrentHP == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

}
