using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ContinueButton;
    [SerializeField] private Button ExitButton;
    private void Awake()
    {
        ContinueButton.onClick.AddListener(Continue);
        ExitButton.onClick.AddListener(Exit);
    }
    private void Continue()
    {
        OnGameManager.Instance.GameResume();
        gameObject.SetActive(false);
    }
    private void Exit()
    {
        OnGameManager.Instance.GameStart();
        SceneManager.LoadScene(0);
    }
}
