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
    /// ���������� ����������, ������� ���������� ������ ��������
    /// </summary>
    public void UpgradeRadius(float _upgrade)
    {
        _shootRadius.radius += _upgrade / 30;
    }
    public void LaunchShooting(List<Vector3> _receivedTransforms, TowerModel _towerModel)
    {
        StartCoroutine(TurnTower(_receivedTransforms, _towerModel));
    }
    public IEnumerator TurnTower(List<Vector3> _enemiesTransforms, TowerModel _towerModel)
    {
        _enemiesTransforms.OrderBy(x => Vector3.Distance(transform.position, x));
        Vector3 _nearestEnemy = _enemiesTransforms.First();
        yield return _direction.transform.DOLookAt(_nearestEnemy, _towerModel.ShootDelay - _bulletTime).WaitForCompletion();
        CreateBullet(_towerModel);
    }
    private void CreateBullet(TowerModel _tower)
    {
        GameObject _newBullet = Instantiate(_bulletPrefab);
        _newBullet.transform.parent = _bulletParent.transform;
        _newBullet.transform.localPosition = _bulletPrefab.transform.position;
        _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        ShootBullet(_newBullet, _tower);
    }
    private void ShootBullet(GameObject _newBullet, TowerModel _tower)
    {
        var z = _newBullet.transform.position.z;
        _newBullet.transform.DOLocalMoveY(_tower.ShootRadius, _bulletTime);
        ShootsNumber += 1;

        if (ShootsNumber < _tower.BulletsNumber)
        {
            OnBulletShot.Invoke(_tower);
        }
        else
        {
            ShootsNumber = 0;
            IsShooting = false;
        }
        Debug.Log("ShootBullet");
    }
}
