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
        if (DataGame.Instance.userdata.score > DataGame.Instance.userdata.highscore)
            DataGame.Instance.userdata.highscore = DataGame.Instance.userdata.score;
        if (OnGameManager.Instance.gameState == GAME_STATE.Game_Over)
        {
            AudioManager.Instance.PlayGlobalSFX("");
            UI.sprite = gameOver;
        }
        else if(OnGameManager.Instance.gameState == GAME_STATE.Game_Complete)
        {
            AudioManager.Instance.PlayGlobalSFX("");
            UI.sprite = gameComplete;
        }
    }

    private void Continue()
    {
        OnGameManager.Instance.GameResume();
        SceneManager.LoadScene(DataGame.Instance.globaldata.Level);
    }
    private void Quit()
    {
        OnGameManager.Instance.GameStart();
        SceneManager.LoadScene(0);
    }
}
