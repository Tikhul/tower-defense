using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveScriptableObject", menuName = "ScriptableObjects/WaveSO", order = 5)]
public class WaveSO : Config
{
    [SerializeField] private float _waveHold;
    [SerializeField] private Dictionary<EnemySO, int> _enemiesAmounts;

    /// <summary>
    /// Задержка перед началом появления врагов в волне
    /// </summary>
    public float WaveHold
    {
        get => _waveHold;
        set => _waveHold = value;
    }

    /// <summary>
    /// Словарь в форме: типа врага - количество в волне
    /// </summary>
    public Dictionary<EnemySO, int> EnemiesAmounts
    {
        get => _enemiesAmounts;
        set => _enemiesAmounts = value;
    }
}
