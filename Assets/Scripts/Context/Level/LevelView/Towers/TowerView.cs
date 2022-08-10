using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;
using System;

public class TowerView : BaseView
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Sprite _towerImage;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    [SerializeField] private SphereCollider _shootRadius;
    [SerializeField] private GameObject _direction;
    [SerializeField] private CellView _cellView;
    public float BulletTime { get; set; } = 1f;
    public bool IsShooting { get; set; } = false;
    public List<EnemyView> EnemyViews { get; set; } = new List<EnemyView>();
    public int ShootsNumber { get; set; }
    
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
    
    private void CreateBullet(TowerModel tower, Vector3 enemyTransform)
    {
        GameObject newBullet = Instantiate(_bulletPrefab);
        newBullet.transform.parent = _bulletParent.transform;
        newBullet.transform.localPosition = _bulletPrefab.transform.position;
        newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        BulletView bulletView = newBullet.GetComponent<BulletView>();
        bulletView.BulletDamage = tower.Damage;
        bulletView.ShootBullet(this, tower, enemyTransform);
    }
    
    public void UpgradeRadius(float upgrade)
    {
        _shootRadius.radius += upgrade;
    }

    public void LaunchShooting(Vector3 nearestEnemy, TowerModel towerModel)
    {
        _cellView.BlockCell();
        ShootsNumber += 1;
        TurnTower(nearestEnemy, towerModel);
    }

    public void TurnTower(Vector3 nearestEnemy, TowerModel towerModel)
    {
        _direction.transform.DOLookAt(nearestEnemy, towerModel.ShootDelay - BulletTime)
            .OnComplete(() => CreateBullet(towerModel, nearestEnemy));
    }
    
    public void RenewData()
    {
        ShootsNumber = 0;
        IsShooting = false;
        _cellView.UnblockCell();
    }
}
