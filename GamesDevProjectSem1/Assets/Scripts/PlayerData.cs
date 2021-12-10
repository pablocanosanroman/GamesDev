using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string m_Time;
    public string m_Name;

    public PlayerData(WinUI data)
    {
        m_Time = data.m_PlayerTime.text;
        m_Name = data.m_PlayerName.text;
    }
}
