using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using System;

public class TowerView : BaseView
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Image _towerImage;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    [SerializeField] private SphereCollider _shootRadius;
    [SerializeField] private GameObject _direction;
    [SerializeField] private Button _cellButton;
    private float _bulletTime = 1f;
    public bool IsShooting { get; set; } = false;
    public int ShootsNumber { get; set; }
    public event Action<TowerModel> OnBulletShot = delegate { };
    public TowerConfig TowerConfig
    {
        get => _towerConfig;
        set => _towerConfig = value;
    }
    public Image TowerImage
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
    public void UpgradeRadius(float _upgrade)
    {
        _shootRadius.radius += _upgrade / 30 - 30;
    }
    public void LaunchShooting(Dictionary<Vector3, EnemyView> _receivedTransforms, TowerModel _towerModel)
    {
  //      Debug.Log("LaunchShooting");
        _cellButton.interactable = false;
        ShootsNumber += 1;
        TurnTower(_receivedTransforms, _towerModel);
    }
    public void TurnTower(Dictionary<Vector3, EnemyView> _enemiesTransforms, TowerModel _towerModel)
    {
  //      Debug.Log("TurnTower");
        Vector3 _nearestEnemy = _enemiesTransforms.Keys.OrderBy(x => Vector3.Distance(transform.position, x)).First();
        Debug.Log(_enemiesTransforms[_nearestEnemy].Config.Id);
        Debug.Log("Ожидание " + _nearestEnemy);
        
        _direction.transform.DOLookAt(_nearestEnemy, _towerModel.ShootDelay - _bulletTime)
            .OnComplete(() => CreateBullet(_towerModel, _nearestEnemy));
        Debug.Log("Реальность " + _enemiesTransforms[_nearestEnemy].transform.position);
    }
    private void CreateBullet(TowerModel _tower, Vector3 _enemyTransform)
    {
  //      Debug.Log("CreateBullet");
        GameObject _newBullet = Instantiate(_bulletPrefab);
        _newBullet.transform.parent = _bulletParent.transform;
        _newBullet.transform.localPosition = _bulletPrefab.transform.position;
        _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        _newBullet.GetComponent<BulletView>().BulletDamage = _tower.Damage;
        StartCoroutine(ShootBullet(_newBullet, _tower, _enemyTransform));
    }
    private IEnumerator ShootBullet(GameObject _newBullet, TowerModel _tower, Vector3 _enemyTransform)
    {
 //       Debug.Log("ShootBullet");
        if(ShootsNumber == _tower.BulletsNumber)
        {
            _newBullet.transform.DOLocalMoveY(
                Vector3.Distance(transform.position, _enemyTransform), _bulletTime)
                .OnComplete(() => DestroyBullet(_newBullet));
            RenewData();
        }
        else if(ShootsNumber < _tower.BulletsNumber)
        {
            yield return _newBullet.transform.DOLocalMoveY(
                Vector3.Distance(transform.position, _enemyTransform), _bulletTime).WaitForCompletion();
            OnBulletShot?.Invoke(_tower);
            DestroyBullet(_newBullet);
        }
    }
    private void DestroyBullet(GameObject _bullet)
    {
        if(_bullet != null)
        {
            Destroy(_bullet);
        }
    }
    private void RenewData()
    {
        ShootsNumber = 0;
        IsShooting = false;
        _cellButton.interactable = true;
    }
}
