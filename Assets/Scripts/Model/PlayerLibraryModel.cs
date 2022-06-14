using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLibraryModel
{
    private PlayerSO playerSettings;
    private int _actualHealth;
    private int _actualCoins;

    /// <summary>
    /// �������� ������ ����������
    /// </summary>
    public int InitialPlayerHealth
    {
        get => playerSettings.InitialHealth;
    }

    /// <summary>
    /// ������ ������ ����������
    /// </summary>
    public int InitialCoins
    {
        get => playerSettings.InitialCoins;
    }

    /// <summary>
    /// ���������� �������� ������
    /// </summary>
    public int ActualPlayerHealth
    {
        get => _actualHealth = InitialPlayerHealth;
        set => _actualHealth = value;
    }

    /// <summary>
    /// ���������� ������ ������
    /// </summary>
    public int ActualCoins
    {
        get => _actualCoins = InitialCoins;
        set => _actualCoins = value;
    }
}
