using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Datas")]
public class EnemySO : ScriptableObject
{
    public int hp;
    public int point;
    public int damge;
}
