using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Sprite gameOver;
    [SerializeField] private Sprite gameComplete;
    [SerializeField] private Text Score;
    [SerializeField] private Image UI;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button quitButton;
    private void OnEnable()
    {
        continueButton.onClick.AddListener(Continue);
        quitButton.onClick.AddListener(Quit);
        Score.text = PlayerController.Instance.PlayerStat.score.ToString();
        if (OnGameManager.Instance.gameState == GAME_STATE.Game_Over)
        {
            UI.sprite = gameOver;
        }
        else if(OnGameManager.Instance.gameState == GAME_STATE.Game_Complete)
        {
            UI.sprite = gameComplete;
        }
    }

    private void Continue()
    {
        AudioManager.Instance.PlayGlobalSFX(null);
        OnGameManager.Instance.GameResume();
        SceneManager.LoadScene(DataGame.Instance.globaldata.Level);
    }
    private void Quit()
    {
        AudioManager.Instance.PlayGlobalSFX(null);
        OnGameManager.Instance.GameStart();
        SceneManager.LoadScene(0);
    }
}
