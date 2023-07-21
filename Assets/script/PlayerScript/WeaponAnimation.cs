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
    private string current_clip;

    private void LateUpdate()
    {
        if (AttackController.mainAttack == true && PlayerController.Instance.KBcountdown <= 0)
            animation_editor(Sword + AttackController.Lv, "attack");
        else
            animation_editor(Empty,null);
    }


    private void animation_editor(string new_st,string new_clip)
    {
        if (new_st == current_st && new_clip == current_clip)
            return;
        anim.Play(new_st);
        AudioManager.Instance.PlayUserSFX(new_clip);
        current_clip = new_clip;
        current_st = new_st;
        
    }
}