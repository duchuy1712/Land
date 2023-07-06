using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AttackController AttackController;
    private string current_st;

    public float health;
    private void LateUpdate()
    {
        UpdateAnim();
    }
    public void UpdateAnim()
    {
        if (PlayerController.Instance.KBcountdown <= 0)
        {
            if (PlayerController.Instance.Grounded())
            {
                if (!AttackController.groundAttack)
                {
                    if (!PlayerController.Instance.running)
                        animation_editor(ANIM_PARAM.Idle);
                    else if (PlayerController.Instance.sliding)
                        animation_editor(ANIM_PARAM.Slide);
                    else if (PlayerController.Instance.running)
                        animation_editor(ANIM_PARAM.Move);
                }
                else
                    animation_editor(ANIM_PARAM.GroundAttack);
            }
            else
            {
                if (!AttackController.airAttack)
                {
                    animation_editor(ANIM_PARAM.Jump);
                }
                else animation_editor(ANIM_PARAM.AirAttack);
            }
        } 
        else if(PlayerController.Instance.KBcountdown > 0)
        {
            animation_editor(ANIM_PARAM.Hurt);
        }
        Color tmp = sprite.color;
        if(PlayerController.Instance.immortal_state == true)
        {
            tmp.a = 0.2f;
        }
        else 
        {
            tmp.a = 1f;
        }
        sprite.color = tmp;
        
    }
    //lệnh chuyển animation
    private void animation_editor(string new_st)
    {
        if (new_st == current_st) // tránh việc animation chạy đè lên chính nó
            return;
        anim.Play(new_st);
        new_st = current_st;
    }

}

public struct ANIM_PARAM
{
    public const string Idle = "idle";
    public const string Move = "move";
    public const string Jump = "jump";
    public const string Slide = "slide";
    public const string AirAttack = "AirAttack";
    public const string GroundAttack = "GroundAttack";
    public const string Hurt = "hurt";
}
