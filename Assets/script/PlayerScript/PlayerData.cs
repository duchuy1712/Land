using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
{
    public static PlayerData Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public int DamageLvl
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.DamageLvl, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.DamageLvl, value);
    }
    public int HpLvl
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.HpLvl, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.HpLvl, value);
    }

    public int CurentLevel
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.CurrentLevel, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.CurrentLevel, value);
    }
    public int ClearedLevel
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.ClearedLevel, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.ClearedLevel, value);
    }
    public int CurrentWeapon
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.CurrentWeapon, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.CurrentWeapon, value);
    }
    public int ManaLvl
    {
        get => PlayerPrefs.GetInt(PlayerDataKey.ManaLvl, 0);
        set => PlayerPrefs.SetInt(PlayerDataKey.ManaLvl, value);
    }
}
public struct PlayerDataKey
{
    public const string DamageLvl = "DamageLvl";
    public const string HpLvl = "HpLvl";
    public const string ManaLvl = "ManaLvl";
    public const string CurrentLevel = "CurrentLevel";
    public const string ClearedLevel = "ClearedLevel";
    public const string CurrentWeapon = "CurrentWeapon";
    public const string CurrentPlayerPosition = "CurrentPlayerPosition";
}
