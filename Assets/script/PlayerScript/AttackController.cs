using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public bool Attack { get; private set; }
    public bool subAttackTrigger => (Input.GetButtonDown("Fire2") && subWeaponName != "" && mana >= ManaCost);
    public bool mainAttack { get; private set; }
    private bool subAttack;
    [SerializeField] private Transform firepoint;
    public int MainWeaponLv { get; private set; }
    public string Lv { get; private set; }
    public int damge { get; private set; }
    public int mana { get; private set; }
    private int ManaCost;
    public int subDamage { get; private set; }
    public string subWeaponName { get; private set; }
    private void Awake()
    {
        MainWeaponLv = DataGame.Instance.userdata.mainWeaponLv;
        subWeaponName = DataGame.Instance.userdata.subWeapon;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || subAttackTrigger)
            Attack = true;
        if (Input.GetButtonDown("Fire1"))
        {
            subAttack = false;
            mainAttack = true;
        }
        else if (subAttackTrigger)
        {
            mainAttack = false;
            subAttack = true;
        }
        mana = PlayerController.Instance.PlayerStat.mana;
        switch (MainWeaponLv)
        {
            case 0:
                Lv = "Lv1";
                damge = 1;
                break;
            case 1:
                Lv = "Lv2";
                damge = 2;
                break;
            case 2:
                Lv = "Lv3";
                damge = 3;
                break;
            default:
                Lv = "Lv1";
                damge = 1;
                break;
        }
        if(subWeaponName == "MagicKnife")
        {
            ManaCost = 4;
            subDamage = 3;
        }
        if(subWeaponName == "Boomerang")
        {
            ManaCost = 1;
            subDamage = 1;
        }
    }
    public void shoot()
    {
        if (subAttack)
        {
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool(subWeaponName);
            obj.transform.position = firepoint.position;
            obj.SetActive(true);
        }
    }

    public void EndAttack()
    {
        Attack = false;
        mainAttack = false;
        subAttack = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            AudioManager.Instance.PlayUserSFX("UpGrade");
            if (collision.gameObject.name == "WeaponUpgrade(Clone)")
            {
                if (MainWeaponLv < 2)
                {
                    MainWeaponLv++;
                }
                else
                {
                    MainWeaponLv = 2;
                }
                return;
            }
            if (collision.gameObject.name == "SupWeapon1(Clone)")
            {
                subWeaponName = "MagicKnife";
            }
            else if (collision.gameObject.name == "SupWeapon2(Clone)")
            {
                subWeaponName = "Boomerang";
            }
        }
    }
}
