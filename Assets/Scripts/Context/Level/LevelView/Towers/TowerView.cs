using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TowerSO _towerSO;
    [SerializeField] private Image _towerImage;

    public TowerSO TowerSO
    {
        get => _towerSO;
        set => _towerSO = value;
    }
    public Image TowerImage
    {
        get => _towerImage;
        set => _towerImage = value;
    }
    public string TowerCostText
    {
        get => _towerSO.Cost.ToString();
    }
    public string TowerDamageText
    {
        get => _towerSO.Damage.ToString();
    }
    public string TowerRadiusText
    {
        get => _towerSO.ShootRadius.ToString();
    }
    public string TowerFrequencyText
    {
        get => _towerSO.ShootFrequency.ToString();
    }
    public string TowerBulletsText
    {
        get => _towerSO.BulletsNumber.ToString();
    }
}
