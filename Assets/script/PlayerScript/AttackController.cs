using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public bool airAttack;
    public bool groundAttack;
    public bool mainAttack;
    public bool supAttack;
    public bool subAttackTrigger => (Input.GetButtonDown("Fire2") && subWeaponName != "" && mana >= ManaCost && supAttack == false);
    [SerializeField] private GameObject weapon;
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
        mana = PlayerController.Instance.PlayerStat.mana;
        switch (MainWeaponLv)
        {
            case 0:
                damge = 1;
                break;
            case 1:
                damge = 2;
                break;
            case 2:
                damge = 3;
                break;
            default:
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
    public void StartAttack()
    {
        if (PlayerController.Instance.Grounded())
        {
            airAttack = false;
            if ((Input.GetButtonDown("Fire1") || subAttackTrigger) && groundAttack == false)
                groundAttack = true;
        }
        else
        {
            groundAttack = false;
            if ((Input.GetButtonDown("Fire1") || subAttackTrigger) && airAttack == false)
                airAttack = true;
        }

        if (Input.GetButtonDown("Fire1") && mainAttack == false)
        {
            supAttack = false;
            mainAttack = true;
        }
        else if (subAttackTrigger)
        {
            mainAttack = false;
            supAttack = true;
        }

    }
    public void swing()
    {
        if (mainAttack == true)
        {
            weapon.SetActive(true);
        }
    }
    public void shoot()
    {
        if (supAttack)
        {
            PlayerController.Instance.PlayerStat.UseMana(ManaCost);
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool(subWeaponName);
            obj.transform.position = firepoint.position;
            obj.SetActive(true);
        }
    }
    public void EndAttack()
    {
        airAttack = false;
        groundAttack = false;
        mainAttack = false;
        supAttack = false;
        weapon.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
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
            collision.gameObject.SetActive(false);
        }
    }
}
