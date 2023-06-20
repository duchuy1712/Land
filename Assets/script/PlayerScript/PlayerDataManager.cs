using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    // scrpit chứa các chỉ số của nhân vật
    public int live; //dữ liệu cần lưu vào file save
    public Vector2 position; // vị trí hồi sinh của nhân vật được cập nhật qua mỗi điểm lưu
    public int hp;
    public int mana;
    public int damage;
    public float speed;
    public float maxJumpHeight;
    public float maxJumpTime;
    public float SliceForce;
    [SerializeField] private PlayerScriptAble baseData;

    private void Start()
    {
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        damage = PlayerData.Instance.DamageLvl + baseData.damage;
        hp = PlayerData.Instance.HpLvl + baseData.hp;
        mana = PlayerData.Instance.ManaLvl + baseData.mana;
    }
}
