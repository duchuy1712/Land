using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Datas")]
public class PlayerScriptAble : ScriptableObject
{
    public int damage;
    public int hp;
    public int mana;
    public float speed;
    public float jumpForce;
}
