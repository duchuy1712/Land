using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public bool airAttack { get; private set; }
    public bool groundAttack { get; private set; }
    public bool mainAttack { get; private set; }
    public bool supAttack { get; private set; }
    private bool supAttackTrigger => (Input.GetButtonDown("Fire2") && subWeaponName != "");

    [SerializeField] private Transform firepoint;
    public int MainWeaponLv { get; private set; }
    public string Lv { get; private set; }
    public int damge { get; private set; }
    public string subWeaponName { get; private set; }

    private void Awake()
    {
        MainWeaponLv = DataGame.Instance.userdata.mainWeaponLv;
        subWeaponName = DataGame.Instance.userdata.subWeapon;
    }
    private void Update()
    {
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
    }
    public void StartAttack()
    {
        if (PlayerController.Instance.Grounded())
        {
            airAttack = false;
            if (Input.GetButtonDown("Fire1") || supAttackTrigger)
                groundAttack = true;
        }
        else
        {
            groundAttack = false;
            if (Input.GetButtonDown("Fire1") || supAttackTrigger)
                airAttack = true;
        }

        if(Input.GetButtonDown("Fire1"))
        {
            supAttack = false;
            mainAttack = true;
        }
        else if (supAttackTrigger)
        {
            mainAttack = false;
            supAttack = true;
        }

    }
    public void shoot()
    {
        if(supAttack)
        {
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
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
        if(collision.gameObject.CompareTag("BigMana"))
        {
            Debug.Log("get mana");
            return;
        }
        if(collision.gameObject.CompareTag("Sup1"))
        {
            subWeaponName = "MagicKnife";
        }
        else if(collision.gameObject.CompareTag("Sup2"))
        {
            subWeaponName = "Boomerang";
        }
    }

}
