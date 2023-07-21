using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSAnimation : MonoBehaviour
{
    string current_st;
    [SerializeField] private Animator anim;
    [SerializeField] private VSController VSController;
    private void Update()
    {
        if (VSController.isShooting)
            animation_editor(VS_Animation.attack);
        else
            animation_editor(VS_Animation.idle);
    }
    private void animation_editor(string new_st)
    {
        if (new_st == current_st)
            return;
        anim.Play(new_st);
        new_st = current_st;
    }
}
public struct VS_Animation
{
    public const string idle = "Idle";
    public const string attack = "Attack";
}
