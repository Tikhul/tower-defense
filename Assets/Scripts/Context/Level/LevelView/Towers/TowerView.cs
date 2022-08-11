using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerView : TowerShoot
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Sprite _towerImage;
    [SerializeField] private SphereCollider _shootRadius;
    public List<EnemyView> EnemyViews { get; set; } = new List<EnemyView>();
    
    public TowerConfig TowerConfig
    {
        get => _towerConfig;
        set => _towerConfig = value;
    }
    public Sprite TowerImage
    {
        get => _towerImage;
        set => _towerImage = value;
    }
    public string TowerCostText => _towerConfig.Cost.ToString();
    public string TowerDamageText => _towerConfig.Damage.ToString();
    public string TowerRadiusText => _towerConfig.ShootRadius.ToString();
    public string TowerFrequencyText => _towerConfig.ShootDelay.ToString();
    public string TowerBulletsText => _towerConfig.BulletsNumber.ToString();

    private void OnEnable()
    {
        ShootsNumber = 0;
        SetRadiusCollider();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            var view = other.gameObject.GetComponent<EnemyView>();
            EnemyViews.Add(view);
            view.EnemyTween.OnKill(() => DeleteEnemyView(view));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            EnemyViews.Remove(other.gameObject.GetComponent<EnemyView>());
        }
    }

    private void DeleteEnemyView(EnemyView enemy)
    {
        EnemyViews.Remove(enemy);
    }
    
    private void SetRadiusCollider()
    {
        _shootRadius.radius = _towerConfig.ShootRadius;
    }
    
    public void UpgradeRadius(float upgrade)
    {
        _shootRadius.radius += upgrade;
    }
}
