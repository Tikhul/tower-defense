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
    private int _shootsNumber;
    public bool IsShooting { get; set; }
    public event Action<TowerModel> OnBulletShot = delegate { };
    public TowerConfig TowerConfig => _towerConfig;
    public string TowerCostText => _towerConfig.Cost.ToString();
    public string TowerDamageText => _towerConfig.Damage.ToString();
    public string TowerRadiusText => _towerConfig.ShootRadius.ToString();
    public string TowerFrequencyText => _towerConfig.ShootDelay.ToString();
    public string TowerBulletsText => _towerConfig.BulletsNumber.ToString();
    private void OnEnable()
    {
        _shootsNumber = 0;
        SetRadiusCollider();
    }
    private void SetRadiusCollider()
    {
        _shootRadius.radius = _towerConfig.ShootRadius / 30;
    }
    /// <summary>
    /// ���������� ����������, ������� ���������� ������ ��������
    /// </summary>
    public void UpgradeRadius(float upgrade)
    {
        _shootRadius.radius += upgrade / 30 - 30;
    }
    public void LaunchShooting(Dictionary<Vector3, EnemyView> receivedTransforms, TowerModel towerModel)
    {
        _cellButton.interactable = false;
        _shootsNumber += 1;
        TurnTower(receivedTransforms, towerModel);
    }
    private void TurnTower(Dictionary<Vector3, EnemyView> enemiesTransforms, TowerModel towerModel)
    {
        Vector3 nearestEnemy = enemiesTransforms.Keys.OrderBy(x => Vector3.Distance(transform.position, x)).First();
        _direction.transform.DOLookAt(nearestEnemy, towerModel.ShootDelay - _bulletTime)
            .OnComplete(() => CreateBullet(towerModel, nearestEnemy));
    }
    private void CreateBullet(TowerModel tower, Vector3 enemyTransform)
    {
        GameObject newBullet = Instantiate(_bulletPrefab);
        
        if (newBullet.transform != null)
        {
            newBullet.transform.parent = _bulletParent.transform;
            newBullet.transform.localPosition = _bulletPrefab.transform.position;
            newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        }
        newBullet.GetComponent<BulletView>().BulletDamage = tower.Damage;
        StartCoroutine(ShootBullet(newBullet, tower, enemyTransform));
    }
    private IEnumerator ShootBullet(GameObject newBullet, TowerModel tower, Vector3 enemyTransform)
    {
        if(_shootsNumber == tower.BulletsNumber)
        {
            newBullet.transform.DOLocalMoveY(
                Vector3.Distance(transform.position, enemyTransform), _bulletTime)
                .SetEase(Ease.Linear)
                .OnComplete(() => DestroyBullet(newBullet));
            RenewData();
        }
        else if(_shootsNumber < tower.BulletsNumber)
        {
            yield return newBullet.transform.DOLocalMoveY(
                Vector3.Distance(transform.position, enemyTransform), _bulletTime)
                .SetEase(Ease.Linear).WaitForCompletion();
            OnBulletShot?.Invoke(tower);
            DestroyBullet(newBullet);
        }
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
        _shootsNumber = 0;
        IsShooting = false;
        _cellButton.interactable = true;
    }
}
