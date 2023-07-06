using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AttackController AttackController;
    private const string Empty = "Empty";
    private const string Sword = "Sword";
    private string current_st;

    private void LateUpdate()
    {
        if ((AttackController.airAttack || AttackController.groundAttack) && AttackController.mainAttack && PlayerController.Instance.KBcountdown <= 0)
             animation_editor(Sword + AttackController.Lv);
        else
            animation_editor(Empty);
    }

    
    private void animation_editor(string new_st)
    {
        if (new_st == current_st)
            return;
        anim.Play(new_st);
        new_st = current_st;
    }
}
