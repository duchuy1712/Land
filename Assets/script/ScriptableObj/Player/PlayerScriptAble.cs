using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Datas")]
public class PlayerScriptAble : ScriptableObject
{
    public int maxHp;
    public int maxMana;
    public int hp;
    public float speed;
    public float maxJumpHeight;
    public float maxJumpTime;
    public float SliceForce;
}
