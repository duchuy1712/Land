using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private Animator anim;
    private string ItemName;
    private string current_st;
    private void Awake()
    {
        switch(item)
        {
            case Item.weapon:
                if (PlayerController.Instance.AttackController.MainWeaponLv < 2)
                {
                    ItemName = "WeaponUpgrade";
                    animation_editor("MainWeapCandle");
                }
                else
                {
                    ItemName = "SmallManaPotion";
                    animation_editor("ManaCandle");
                }
                break;
            case Item.subweap1:
                if (PlayerController.Instance.AttackController.subWeaponName != "MagicKnife")
                {
                    ItemName = "SupWeapon1";
                    animation_editor("SupWeapCandle");
                }
                else
                {
                    ItemName = "SmallManaPotion";
                    animation_editor("ManaCandle");
                }
                break;
            case Item.subweap2:
                if (PlayerController.Instance.AttackController.subWeaponName != "Boomerang")
                {
                    ItemName = "SupWeapon2";
                    animation_editor("SupWeapCandle");
                }
                else
                {
                    ItemName = "SmallManaPotion";
                    animation_editor("ManaCandle");
                }
                break;
            case Item.bigMana:
                ItemName = "BigManaPotion";
                animation_editor("ManaCandle");
                break;
            case Item.smallMana:
                ItemName = "SmallManaPotion";
                animation_editor("ManaCandle");
                break;
            case Item.bigHealth:
                ItemName = "BigHealth";
                animation_editor("HeathCandle");
                break;
            case Item.smallHealth:
                ItemName = "SmallHealth";
                animation_editor("HeathCandle");
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("subWeapon"))
        {
            AudioManager.Instance.PlayGlobalSFX("Hit");
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool(ItemName);
            obj.transform.position = transform.position;
            obj.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    private void animation_editor(string new_st)
    {
        if (new_st == current_st)
            return;
        anim.Play(new_st);
        new_st = current_st;
    }
}
public enum Item
{
    smallHealth,
    bigHealth,
    smallMana,
    bigMana,
    subweap1,
    subweap2,
    weapon,
}