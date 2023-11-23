using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie2Animation : MonoBehaviour
{
    string current_st;
    public Animator anim;
    private void Update()
    {
        if (Zombie2Controller.Instance.isShooting)
            animation_editor(Zombie2_Animation.attack);
        else
            animation_editor(Zombie2_Animation.idle);
    }
    private void animation_editor(string new_st)
    {
        if (new_st == current_st)
            return;
        anim.Play(new_st);
        new_st = current_st;
    }
}
public struct Zombie2_Animation
{
   public const string idle = "idle";
   public const string attack = "attack";
}
