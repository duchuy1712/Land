using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameManager : Singleton<OnGameManager>
{
    public GAME_STATE gameState { get; private set; }
    public void GameStart()
    {
        gameState = GAME_STATE.Game_Start;
        Time.timeScale = 1;
    }
    public void GamePause()
    {
        gameState = GAME_STATE.Game_Pause;
        Time.timeScale = 0;
    }
    public void GameResume()
    {
        gameState = GAME_STATE.Game_Resume;
        Time.timeScale = 1;
    }
    public void GameCompelete()
    {
        gameState = GAME_STATE.Game_Complete;
        AudioManager.Instance.PlayGlobalSFX("Victory");
        Time.timeScale = 0;

    }
    public void GameOver()
    {
        gameState = GAME_STATE.Game_Over;
        AudioManager.Instance.PlayGlobalSFX("GameOver");
        Time.timeScale = 0;
    }
}
public enum GAME_STATE
{
    Game_Start,
    Game_Pause,
    Game_Resume,
    Game_Complete,
    Game_Over
}
