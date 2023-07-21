using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int nextLevelIndex;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTag"))
        {
            Save();
            DataGame.Instance.globaldata.Level = nextLevelIndex;
            OnGameManager.Instance.GameCompelete();
        }
    }

    private void Save()
    {
        DataGame.Instance.userdata.Live = PlayerController.Instance.PlayerStat.live;
        DataGame.Instance.userdata.mainWeaponLv = PlayerController.Instance.AttackController.MainWeaponLv;
        DataGame.Instance.userdata.subWeapon = PlayerController.Instance.AttackController.subWeaponName;
        DataGame.Instance.userdata.score = PlayerController.Instance.PlayerStat.score;
    }
}
