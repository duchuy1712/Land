using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [SerializeField] private int Id;
    [SerializeField] private Animator anim;
    private string ItemName;
    private string current_st;
    private void Awake()
    {
        switch(Id)
        {
            case 0:
                ItemName = "WeaponUpgrade";
                animation_editor("MainWeapCandle");
                break;
            case 1:
                ItemName = "SupWeapon1";
                animation_editor("SupWeapCandle");
                break;
            case 2:
                ItemName = "SupWeapon2";
                animation_editor("SupWeapCandle");
                break;
            case 3:
                ItemName = "BigManaPotion";
                animation_editor("ManaCandle");
                break;
            case 4:
                ItemName = "SmallManaPotion";
                animation_editor("ManaCandle");
                break;
            case 5:
                ItemName = "BigHeath";
                animation_editor("HeathCandle");
                break;
            case 6:
                ItemName = "SmallHeath";
                animation_editor("HeathCandle");
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Sword"))
        {
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
