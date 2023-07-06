using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    //dữ liệu lấy từ prefab
    private int mana;
    private int score;
    private int highScore;
    private int damage;
    //dữ liệu được lấy từ scriptable object
    public int live { get; private set; }
    public int hp { get; private set; }
    public float speed { get; private set; }
    public float maxJumpHeight { get; private set; }
    public float maxJumpTime { get; private set; }
    public float SliceForce { get; private set; }
    [SerializeField] private PlayerScriptAble baseData;

    private void OnEnable()
    {
        Setupdata();
    }
    private void Setupdata()
    {
        hp = baseData.hp;
        speed = baseData.speed;
        maxJumpHeight = baseData.maxJumpHeight;
        maxJumpTime = baseData.maxJumpTime;
        SliceForce = baseData.SliceForce;
        live = DataGame.Instance.userdata.Live;
        mana = DataGame.Instance.userdata.mana;
        score = DataGame.Instance.userdata.score;
    }

    public void hurt(int _amount)
    {
        if(hp <= 0)
        {
            if (live > 0)
                hp = baseData.hp;
                live--;

            gameObject.SetActive(false);
        }
        else if(hp > 0)
            hp -= _amount;
        
    }

    public void Heal(int _amount)
    {
        hp += _amount;
    }

}
