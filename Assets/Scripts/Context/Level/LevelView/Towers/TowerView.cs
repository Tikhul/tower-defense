using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
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
        get => _towerConfig.ShootFrequency.ToString();
    }
    public string TowerBulletsText
    {
        get => _towerConfig.BulletsNumber.ToString();
    }
}
