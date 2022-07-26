using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;

public class TowerView : BaseView
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Image _towerImage;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    [SerializeField] private SphereCollider _shootRadius;
    public bool IsShooting { get; set; } = false;
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
    public void CreateBullets(TowerModel _tower)
    {
        StartCoroutine(WaitAndShoot(_tower));
    }
    /// <summary>
    /// Отсрочка выстрела, настройка снаряда
    /// </summary>
    /// <param name="_tower"></param>
    /// <returns></returns>
    private IEnumerator WaitAndShoot(TowerModel _tower)
    {
        for (int i = 0; i < _tower.BulletsNumber; i++)
        {
            yield return new WaitForSeconds(_tower.ShootDelay);
            GameObject _newBullet = Instantiate(_bulletPrefab);
            _newBullet.transform.parent = _bulletParent.transform;
            _newBullet.transform.localPosition = _bulletPrefab.transform.position;
            _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
            ShootBullet(_newBullet, _tower.ShootRadius);
        }  
    }
    /// <summary>
    /// Выстрел снарядом
    /// </summary>
    /// <param name="_newBullet"></param>
    /// <param name="_radius"></param>
    private void ShootBullet(GameObject _newBullet, float _radius)
    {
        var z = _newBullet.transform.position.z;
        _newBullet.transform.DOMove(new Vector3(_newBullet.transform.position.x,
             _newBullet.transform.position.y,
            z += _radius
            ), 1f); ;
        Debug.Log("ShootBullet");
    }
    /// <summary>
    /// Увеличение коллайдера, который показывает радиус стрельбы
    /// </summary>
    public void UpgradeRadius(float _upgrade)
    {
        _shootRadius.radius += _upgrade / 30;
    }
    /// <summary>
    /// Поворот башни к ближайшему врагу
    /// </summary>
    public void TurnTower(List<Vector3> _enemiesTransforms)
    {
        _enemiesTransforms.OrderBy(x => Vector3.Distance(transform.position, x));
        Vector3 _nearestEnemy = _enemiesTransforms.Last();
        transform.DOLocalRotate(new Vector3(0, 0, 90+_nearestEnemy.z), TowerConfig.ShootDelay);
    }
}
