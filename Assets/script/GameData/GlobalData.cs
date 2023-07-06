using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    public int Level
    {
        get => PlayerPrefs.GetInt(GlobalDataKey.Level, 0);
        set => PlayerPrefs.SetInt(GlobalDataKey.Level, value);
    }
}

public struct GlobalDataKey
{
    public const string Level = "Level";
}
