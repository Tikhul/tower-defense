using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : BaseView
{
    [SerializeField] private TowerConfig _towerConfig;
    [SerializeField] private Image _towerImage;

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
    public string TowerCostText
    {
        get => _towerConfig.Cost.ToString();
    }
    public string TowerDamageText
    {
        get => _towerConfig.Damage.ToString();
    }
    public string TowerRadiusText
    {
        get => _towerConfig.ShootRadius.ToString();
    }
    public string TowerFrequencyText
    {
        get => _towerConfig.ShootDelay.ToString();
    }
    public string TowerBulletsText
    {
        get => _towerConfig.BulletsNumber.ToString();
    }
    public void CreateBullets(TowerModel _tower)
    {
        StartCoroutine(WaitAndShoot(_tower));
    }
    private IEnumerator WaitAndShoot(TowerModel _tower)
    {
        for (int i = 0; i < _tower.BulletsNumber; i++)
        {
            yield return new WaitForSeconds(_tower.ShootDelay);
            Debug.Log("Shoot");
        }  
    }
}
