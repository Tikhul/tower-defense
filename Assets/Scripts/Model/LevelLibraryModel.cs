using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLibraryModel
{
    private LevelSO _levelSettings;

    /// <summary>
    /// Конфиг маршрута, по которому будут двигаться враги в уровне
    /// </summary>
    public EnemyWaySO EnemyWay
    {
        get => _levelSettings.EnemyWay;
    }

    /// <summary>
    /// Cписок волн, из которых состоит уровень
    /// </summary>
    public List<WaveSO> Waves
    {
        get => _levelSettings.Waves;
    }
}
