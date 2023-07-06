using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestSaveAndLoadScreen : MonoBehaviour
{
    public TestSaveAndLoadScreen tsals { get; private set; }
    private void Awake()
    {
        if (tsals != null)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetInt(GlobalDataKey.Level, 0);
            Debug.Log("màn lv1");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt(GlobalDataKey.Level, 2);
            Debug.Log("màn datatest");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt(GlobalDataKey.Level));
        }
    }
}
