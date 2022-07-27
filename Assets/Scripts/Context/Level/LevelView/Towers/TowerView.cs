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
    private float _bulletTime = 0.5f;
    public bool IsShooting { get; set; } = false;
    public int ShootsNumber { get; set; } = 0;
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
        _shootRadius.radius += _upgrade / 30;
    }
    public void LaunchShooting(List<Vector3> _receivedTransforms, TowerModel _towerModel)
    {
        _cellButton.interactable = false;
        ShootsNumber += 1;
        StartCoroutine(TurnTower(_receivedTransforms, _towerModel));
    }
    public IEnumerator TurnTower(List<Vector3> _enemiesTransforms, TowerModel _towerModel)
    {
        Vector3 _nearestEnemy = _enemiesTransforms.OrderBy(x => Vector3.Distance(transform.position, x)).First();
        yield return _direction.transform.DOLookAt(_nearestEnemy, _towerModel.ShootDelay).WaitForCompletion();
        CreateBullet(_towerModel, _nearestEnemy);
    }
    private void CreateBullet(TowerModel _tower, Vector3 _enemyTransform)
    {
        GameObject _newBullet = Instantiate(_bulletPrefab);
        _newBullet.transform.parent = _bulletParent.transform;
        _newBullet.transform.localPosition = _bulletPrefab.transform.position;
        _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        _newBullet.GetComponent<BulletView>().BulletDamage = _tower.Damage;
        ShootBullet(_newBullet, _tower, _enemyTransform);
    }
    private void ShootBullet(GameObject _newBullet, TowerModel _tower, Vector3 _enemyTransform)
    {
        Tween _tween = _newBullet.transform.DOLocalMoveY(Vector3.Distance(transform.position, _enemyTransform), _bulletTime);
        OnBulletShot?.Invoke(_tower);

        if (ShootsNumber >= _tower.BulletsNumber)
        {
            ShootsNumber = 0;
            IsShooting = false;
            _tween.OnComplete(UnBlockCell);
        }
        Debug.Log("ShootBullet");
    }

    private void UnBlockCell()
    {
        _cellButton.interactable = true;
    }
}
