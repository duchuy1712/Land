using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private AttackController AttackController;
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private SpriteRenderer weapon;
    [SerializeField] private Sprite weaponLv1, weaponLv2, weaponLv3;

    private void OnEnable()
    {
        AudioManager.Instance.PlayUserSFX("attack");
        switch (AttackController.MainWeaponLv)
        {
            case 0:
                hitbox.offset = new Vector2(3.411802f, -1.43344f);
                hitbox.size = new Vector2(2.596104f, 0.6961317f);
                weapon.sprite = weaponLv1;
                break;
            case 1:
                hitbox.offset = new Vector2(3.941008f, -1.389339f);
                hitbox.size = new Vector2(3.654514f, 0.7843323f);
                weapon.sprite = weaponLv2;
                break;
            case 2:
                hitbox.offset = new Vector2(4.634014f, -1.383039f);
                hitbox.size = new Vector2(5.040527f, 0.7969322f);
                weapon.sprite = weaponLv3;
                break;
            default:
                hitbox.offset = new Vector2(3.411802f, -1.43344f);
                hitbox.size = new Vector2(2.596104f, 0.6961317f);
                weapon.sprite = weaponLv1;
                break;
        }
    }
}