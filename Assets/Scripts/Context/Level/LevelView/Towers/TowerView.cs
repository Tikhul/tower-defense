using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : BaseView
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Image _towerImage;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;

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
    public void CreateBullets(TowerModel _tower)
    {
        StartCoroutine(WaitAndShoot(_tower));
    }
    private IEnumerator WaitAndShoot(TowerModel _tower)
    {
        for (int i = 0; i < _tower.BulletsNumber; i++)
        {
            yield return new WaitForSeconds(_tower.ShootDelay);
            GameObject _newBullet = Instantiate(_bulletPrefab);
            _newBullet.transform.parent = _bulletParent.transform;
            _newBullet.transform.localPosition = _bulletPrefab.transform.position;
            _newBullet.transform.localScale = _bulletPrefab.transform.localScale;
            ShootBullet(_newBullet);
        }  
    }
    private void ShootBullet(GameObject _newBullet)
    {
        _newBullet.GetComponent<Rigidbody>().isKinematic = false;
        _newBullet.GetComponent<Rigidbody>().useGravity = true;
       _newBullet.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
        Debug.Log("ShootBullet");
    }
}
