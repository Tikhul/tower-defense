using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLibraryModel
{
    private LevelSO _levelSettings;

    /// <summary>
    /// ������ ��������, �� �������� ����� ��������� ����� � ������
    /// </summary>
    public EnemyWaySO EnemyWay
    {
        get => _levelSettings.EnemyWay;
    }

    /// <summary>
    /// C����� ����, �� ������� ������� �������
    /// </summary>
    public List<WaveSO> Waves
    {
        get => _levelSettings.Waves;
    }
}
