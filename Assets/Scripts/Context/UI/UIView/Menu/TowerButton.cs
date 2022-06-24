using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _towerButtonText;
    [SerializeField] private Image _towerButtonImage;

    public TMPro.TMP_Text TowerButtonText
    {
        get => _towerButtonText;
        set => _towerButtonText = value;
    }

    public Image TowerButtonImage
    {
        get => _towerButtonImage;
        set => _towerButtonImage = value;
    }
}
