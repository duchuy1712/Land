using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AttackController AttackController;
    private const string Empty = "Empty";
    private const string Sword = "Sword";
    private string Lv;
    private string current_st;

    private void LateUpdate()
    {
        if ((AttackController.airAttack || AttackController.groundAttack) && AttackController.mainAttack)
             animation_editor(Sword + Lv);
        else
            animation_editor(Empty);
    }

    private void Update()
    {
        switch (AttackController.MainLv)
        {
            case 0:
                Lv = "Lv1";
                break;
            case 1:
                Lv = "Lv2";
                break;
            case 2:
                Lv = "Lv3";
                break;
            default:
                Lv = "Lv1";
                break;
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
