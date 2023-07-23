using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    //dữ liệu lấy từ prefab
    public int mana { get; private set; }
    public int score { get; private set; }
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
    private void Death()
    {
        live -= 1;
        if (live > 0)
        {
           SceneManager.LoadScene(DataGame.Instance.globaldata.Level);
           DataGame.Instance.userdata.score = score;
           PlayerPrefs.DeleteKey(UserDataKey.mainWeapon);
           PlayerPrefs.DeleteKey(UserDataKey.subWeapon);
           DataGame.Instance.userdata.Live = live;
        }
        else if(live <= 0)
        {
            PlayerPrefs.DeleteKey(UserDataKey.score);
            PlayerPrefs.DeleteKey(UserDataKey.Live);
            OnGameManager.Instance.GameOver();
        }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            AudioManager.Instance.PlayUserSFX("GetItem");
            if (collision.gameObject.name == "BigManaPotion(Clone)")
            {
                PlayerController.Instance.PlayerStat.GetMana(5);
            }
            else if (collision.gameObject.name == "SmallManaPotion(Clone)")
            {
                PlayerController.Instance.PlayerStat.GetMana(2);
            }
            else if (collision.gameObject.name == "SmallHealth(Clone)")
            {
                PlayerController.Instance.PlayerStat.Heal(2);
            }
            else if (collision.gameObject.name == "BigHealth(Clone)")
            {
                PlayerController.Instance.PlayerStat.Heal(5);
            }
            collision.gameObject.SetActive(false);
        }
    }
    
    public void hurt(int _amount)
    {
        hp -= _amount;
        if (hp <= 0)
        {
            hp = 0;
            AudioManager.Instance.PlayMusic(null);
            AudioManager.Instance.PlayGlobalSFX("Death");
        }
    }
    private void Heal(int _amount)
    {
        if(hp < baseData.maxHp)
            hp += _amount;
        else if (hp >= baseData.maxHp)
            hp = baseData.maxHp;
    }
    private void GetMana(int _amount)
    {
        if (mana < baseData.maxMana)
            mana += _amount;
        else if (mana >= baseData.maxMana)
            mana = baseData.maxMana;
    }
    public void UseMana(int _amount)
    {
        if(mana >= _amount)
            mana -= _amount;
    }
    public void GetPoint(int _amount)
    {
        score += _amount;
    }
}