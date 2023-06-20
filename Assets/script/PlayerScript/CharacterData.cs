using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    public int hp;
    public int damge;

    public virtual void GetDamge(int amount, System.Action<bool> isDead)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            isDead?.Invoke(true);
        }
        else
            isDead?.Invoke(false);
    }

    public void Attack(CharacterData target)
    {
        target.GetDamge(damge, (isDead) => { });
    }

}
