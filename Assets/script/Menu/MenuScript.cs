using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Button startButton;
    public Button continueButton;
    public Button exitButton;
    private int Level;

    private void Awake()
    {
        Level = DataGame.Instance.globaldata.Level;
    }
    private void Start()
    {
        startButton.onClick.AddListener(NewGame);
        continueButton.onClick.AddListener(Continue);
        exitButton.onClick.AddListener(Exit);
    }

    private void NewGame()
    {
        resetLevel();
        SceneManager.LoadScene(Level);
    }
    private void Continue()
    {
        SceneManager.LoadScene(Level);
    }

    private void Exit()
    {
        Application.Quit();
    }
    
    private void resetLevel()
    {
        DataGame.Instance.globaldata.Level = 1;
        DataGame.Instance.userdata.Live = 3;
        DataGame.Instance.userdata.mana = 5;
        DataGame.Instance.userdata.mainWeaponLv = 0;
        DataGame.Instance.userdata.subWeapon = "MagicKnife";
        DataGame.Instance.userdata.score = 0;
        Level = DataGame.Instance.globaldata.Level;
    }    
}
