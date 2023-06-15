using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public bool airAttack { get; private set; }
    public bool groundAttack { get; private set; }
    
    public bool mainAttack { get; private set; }
    public bool supAttack { get; private set; }
    private bool supAttackTrigger => (Input.GetButtonDown("Fire2") && WeaponName != "");

    [SerializeField] private Transform firepoint;
    public int damage;
    public int MainLv { get; private set; }
    [SerializeField] private string WeaponName;

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
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool(WeaponName);
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
            if (MainLv < 2)
            {
                MainLv++;
            }
            else
            {
                MainLv = 2;
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
            WeaponName = "MagicKnife";
        }
        else if(collision.gameObject.CompareTag("Sup2"))
        {
            WeaponName = "Boomerang";
        }
    }

}
