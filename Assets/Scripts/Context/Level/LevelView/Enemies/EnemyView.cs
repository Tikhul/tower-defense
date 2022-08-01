using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : BaseView
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private DOTweenPath _path;
    [SerializeField] private TMPro.TMP_Text _enemyData;
    private int _actualEnemyHealth;
    public Tween EnemyTween { get; set; }
    public EnemyConfig Config => _config;
    public int ActualEnemyHealth
    {
        get => _actualEnemyHealth = Config.InitialHealth;
        set => _actualEnemyHealth = value;
    }
    public DOTweenPath Path => _path;
    public event Action<int> OnEnemyWayCompleted = delegate { };
    private void OnEnable()
    {
        ShowEnemyHealth(ActualEnemyHealth);
    }
    public void FillWayPoints(List<Vector3> _receivedTransforms)
    {
        var _duration = _receivedTransforms.Count / _config.Speed;
        Path.wps.AddRange(_receivedTransforms);
        EnemyTween = transform.DOPath(Path.wps.ToArray(), _duration).OnComplete(PerformAfterPath);
    }
    private void PerformAfterPath()
    {
        OnEnemyWayCompleted?.Invoke(Config.Damage);
        ClearEnemies();
    }
    public void ClearEnemies()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
    public void Damage(int _damage)
    {
        _actualEnemyHealth -= _damage;
        ShowEnemyHealth(_actualEnemyHealth);
        if (_actualEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void ShowEnemyHealth(int _health)
    {
        _enemyData.text = _health.ToString();
    }
}
