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
    public event Action<int> OnEnemyWayCompleted = delegate { };
    private void OnEnable()
    {
        ShowEnemyHealth(_actualEnemyHealth);
    }
    public void FillWayPoints(List<Vector3> receivedTransforms)
    {
        _path.wps.AddRange(receivedTransforms);
        EnemyTween = transform.DOPath(_path.wps.ToArray(), _config.Speed).SetEase(Ease.Linear).OnComplete(PerformAfterPath);
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
    public void Damage(int damage)
    {
        _actualEnemyHealth -= damage;
        ShowEnemyHealth(_actualEnemyHealth);
        
        if (_actualEnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void ShowEnemyHealth(int health)
    {
        _enemyData.text = health.ToString();
    }
}
