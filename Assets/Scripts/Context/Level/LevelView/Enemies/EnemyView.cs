using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : BaseView
{
    [SerializeField] private EnemyConfig _config;
    [SerializeField] private DOTweenPath _path;
    [SerializeField] private TMPro.TMP_Text _enemyData;
    public Tween EnemyTween { get; set; }
    public EnemyConfig Config => _config;
    public DOTweenPath Path => _path;
    public event Action OnEnemyWayCompleted = delegate { };

    private void OnEnable()
    {
        ShowEnemyHealth(Config.InitialHealth);
    }

    public void FillWayPoints(List<Vector3> receivedTransforms)
    {
        Path.wps.AddRange(receivedTransforms);
        EnemyTween = transform.DOPath(Path.wps.ToArray(), _config.Speed)
            .SetSpeedBased()
            .SetEase(Ease.Linear)
            .OnComplete(PerformAfterPath);        
    }

    private void PerformAfterPath()
    {
        OnEnemyWayCompleted?.Invoke();
        ClearEnemies();
    }

    public void ClearEnemies()
    {
     //   transform.DOKill();
        Destroy(gameObject);
    }
    
    public void ShowEnemyHealth(int health)
    {
        _enemyData.text = health.ToString();
    }

    public void DestroyEnemy()
    {
        Debug.Log("DestroyEnemy");
        Destroy(gameObject);
    }
}
