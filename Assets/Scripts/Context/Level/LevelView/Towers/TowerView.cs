using System.Collections;
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
        _shootRadius.radius = _towerConfig.ShootRadius / 30;
    }
    /// <summary>
    /// Увеличение коллайдера, который показывает радиус стрельбы
    /// </summary>
    public void UpgradeRadius(float upgrade)
    {
        _shootRadius.radius += upgrade / 30 - 30;
    }
    public void LaunchShooting(Dictionary<Vector3, EnemyView> receivedTransforms, TowerModel towerModel)
    {
        _cellView.Interactable = false;
        ShootsNumber += 1;
        TurnTower(receivedTransforms, towerModel);
    }
    public void TurnTower(Dictionary<Vector3, EnemyView> enemiesTransforms, TowerModel towerModel)
    {
        Vector3 nearestEnemy = enemiesTransforms.Keys.OrderBy(x => Vector3.Distance(transform.position, x)).First();
        Debug.Log(enemiesTransforms[nearestEnemy].Config.Id);
        Debug.Log("Ожидание " + nearestEnemy);
        
        _direction.transform.DOLookAt(nearestEnemy, towerModel.ShootDelay - _bulletTime)
            .OnComplete(() => CreateBullet(towerModel, nearestEnemy));
        Debug.Log("Реальность " + enemiesTransforms[nearestEnemy].transform.position);
    }
    private void CreateBullet(TowerModel tower, Vector3 enemyTransform)
    {
  //      Debug.Log("CreateBullet");
        GameObject _newBullet = Instantiate(_bulletPrefab);
        _newBullet.transform.parent = _bulletParent.transform;
        _newBullet.transform.localPosition = _bulletPrefab.transform.position;
        _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        _newBullet.GetComponent<BulletView>().BulletDamage = tower.Damage;
        StartCoroutine(ShootBullet(_newBullet, tower, enemyTransform));
    }
    private IEnumerator ShootBullet(GameObject newBullet, TowerModel tower, Vector3 enemyTransform)
    {
 //       Debug.Log("ShootBullet");
        if(ShootsNumber == tower.BulletsNumber)
        {
            newBullet.transform.DOLocalMoveY(
                Vector3.Distance(transform.position, enemyTransform), _bulletTime)
                .OnComplete(() => DestroyBullet(newBullet));
            RenewData();
        }
        else if(ShootsNumber < tower.BulletsNumber)
        {
            yield return newBullet.transform.DOLocalMoveY(
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
}
