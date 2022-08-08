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
    private float _bulletTime = 1f;
    public bool IsShooting { get; set; } = false;
    public List<EnemyView> EnemyViews { get; set; } = new List<EnemyView>();
    public int ShootsNumber { get; set; }
    public event Action<TowerModel> OnBulletShot = delegate { };
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

    private void SetRadiusCollider()
    {
        _shootRadius.radius = _towerConfig.ShootRadius;
    }

    /// <summary>
    /// Увеличение коллайдера, который показывает радиус стрельбы
    /// </summary>
    public void UpgradeRadius(float upgrade)
    {
        _shootRadius.radius += upgrade;
    }

    public void LaunchShooting(Vector3 nearestEnemy, TowerModel towerModel)
    {
        _cellView.Interactable = false;
        ShootsNumber += 1;
        TurnTower(nearestEnemy, towerModel);
    }

    public void TurnTower(Vector3 nearestEnemy, TowerModel towerModel)
    {
        Debug.Log("Ожидание " + nearestEnemy);
        
        _direction.transform.DOLookAt(nearestEnemy, towerModel.ShootDelay - _bulletTime)
            .OnComplete(() => CreateBullet(towerModel, nearestEnemy));

        // Для дебага
        if (EnemyViews.Any())
        {
            var enemy = EnemyViews.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).First();
            Debug.Log("Реальность " + enemy.gameObject.transform.position);
        }
    }

    private void CreateBullet(TowerModel tower, Vector3 enemyTransform)
    {
  //      Debug.Log("CreateBullet");
        GameObject _newBullet = Instantiate(_bulletPrefab);
        _newBullet.transform.parent = _bulletParent.transform;
        _newBullet.transform.localPosition = _bulletPrefab.transform.position;
        _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        _newBullet.GetComponent<BulletView>().BulletDamage = tower.Damage;
        ShootBullet(_newBullet, tower, enemyTransform);
    }

    private void ShootBullet(GameObject newBullet, TowerModel tower, Vector3 enemyTransform)
    {
 //       Debug.Log("ShootBullet");
        if(ShootsNumber == tower.BulletsNumber)
        {
            newBullet.transform.DOLocalMoveZ(
                Vector3.Distance(transform.position, enemyTransform), _bulletTime)
                .OnComplete(() => DestroyBullet(newBullet));
            RenewData();
        }
        else if(ShootsNumber < tower.BulletsNumber)
        {
            newBullet.transform.DOLocalMoveZ(
                Vector3.Distance(transform.position, enemyTransform), _bulletTime)
                .OnComplete(() => AfterShoot(tower, newBullet));
        }
    }

    private void AfterShoot(TowerModel tower, GameObject bullet)
    {
        OnBulletShot?.Invoke(tower);
        DestroyBullet(bullet);
    }

    private void DestroyBullet(GameObject bullet)
    {
        if(bullet != null)
        {
            Destroy(bullet);
        }
    }

    private void RenewData()
    {
        ShootsNumber = 0;
        IsShooting = false;
        _cellView.Interactable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            EnemyViews.Add(other.gameObject.GetComponent<EnemyView>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            EnemyViews.Remove(other.gameObject.GetComponent<EnemyView>());
        }
    }
}
