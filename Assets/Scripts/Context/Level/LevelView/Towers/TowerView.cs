using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TowerSO _towerSO;
    [SerializeField] private Image _towerImage;
    [SerializeField] private string _towerText;

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

    public string TowerText
    {
        get => _towerSO.Cost.ToString();
    }
}
