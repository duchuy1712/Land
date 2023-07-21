using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIGame : MonoBehaviour
{
    public SubWeaponIcon[] icon;
    [SerializeField] private Text live;
    [SerializeField] private Text mana;
    [SerializeField] private Image supweaponicon;
    [SerializeField] private Text Score;
    [SerializeField] private Text HightScore;
    [SerializeField] private Slider HealthBar;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject PauseMenu;


    private void Update()
    {
        live.text = PlayerController.Instance.PlayerStat.live.ToString();
        mana.text = PlayerController.Instance.PlayerStat.mana.ToString();
        Score.text = "Score - " + PlayerController.Instance.PlayerStat.score;
        HightScore.text = "HiScore - " + DataGame.Instance.userdata.highscore;
        HealthBar.value = PlayerController.Instance.PlayerStat.hp;
        SubWeaponIcon(PlayerController.Instance.AttackController.subWeaponName);
        if (OnGameManager.Instance.gameState == GAME_STATE.Game_Over || OnGameManager.Instance.gameState == GAME_STATE.Game_Complete)
        {
            GameOver.SetActive(true);
        }
        else
        {
            GameOver.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OnGameManager.Instance.gameState == GAME_STATE.Game_Pause)
            {
                OnGameManager.Instance.GameResume();
                PauseMenu.SetActive(false);
            }
            else if(OnGameManager.Instance.gameState != GAME_STATE.Game_Pause)
            {
                OnGameManager.Instance.GamePause();
                PauseMenu.SetActive(true);
            }
        }
    }
    private void SubWeaponIcon(string name)
    {
        SubWeaponIcon s = Array.Find(icon, x => x.Name == name);
        if (s != null)
            supweaponicon.sprite = s.Icon;
        else
            return;
    }
}
