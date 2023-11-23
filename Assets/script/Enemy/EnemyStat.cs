using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private EnemySO Stat;
    private int hp;
    private int damage;
    private int point;

    private void Awake()
    {
        hp = Stat.hp;
        damage = Stat.damge;
        point = Stat.point;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
            hurt(PlayerController.Instance.AttackController.damge);
        } 
        if(collision.gameObject.CompareTag("subWeapon"))
        {
            hurt(PlayerController.Instance.AttackController.subDamage);
        }
    }
    private void hurt(int _amount)
    {
        hp -= _amount;
        AudioManager.Instance.PlayGlobalSFX("Hit");
        if (hp <= 0)
        {
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool("Hit");
            obj.transform.position = this.gameObject.transform.position;
            obj.SetActive(true);
            gameObject.SetActive(false);
            PlayerController.Instance.PlayerStat.GetPoint(point);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            PlayerController.Instance.PlayerStat.hurt(damage);
        }

    }
}
