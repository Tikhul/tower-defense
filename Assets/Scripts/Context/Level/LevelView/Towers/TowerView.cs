using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerView : MonoBehaviour
{
    [SerializeField] private TowerSO _towerSO;
    [SerializeField] private Image _towerImage;
    [SerializeField] private TMPro.TMP_Text _towerText;

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

    public TMPro.TMP_Text TowerText
    {
        get => _towerText;
        set => _towerText = value;
    }
}
