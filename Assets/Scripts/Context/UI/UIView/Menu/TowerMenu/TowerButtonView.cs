using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonView : View
{
    [SerializeField] private TMPro.TMP_Text _towerCostText;
    [SerializeField] private TMPro.TMP_Text _towerDamageText;
    [SerializeField] private TMPro.TMP_Text _towerRadiusText;
    [SerializeField] private TMPro.TMP_Text _towerFrequencyText;
    [SerializeField] private TMPro.TMP_Text _towerBulletsText;
    [SerializeField] private Image _towerButtonImage;
    [SerializeField] private Button _button;
    public TowerView TowerView { get; set; }
    public event Action OnTowerButtonClick = delegate { };
    public TMPro.TMP_Text TowerCostText
    {
        get => _towerCostText;
        set => _towerCostText = value;
    }
    public TMPro.TMP_Text TowerDamageText
    {
        get => _towerDamageText;
        set => _towerDamageText = value;
    }
    public TMPro.TMP_Text TowerRadiusText
    {
        get => _towerRadiusText;
        set => _towerRadiusText = value;
    }
    public TMPro.TMP_Text TowerFrequencyText
    {
        get => _towerFrequencyText;
        set => _towerFrequencyText = value;
    }
    public TMPro.TMP_Text TowerBulletsText
    {
        get => _towerBulletsText;
        set => _towerBulletsText = value;
    }
    public Image TowerButtonImage
    {
        get => _towerButtonImage;
        set => _towerButtonImage = value;
    }
    private void OnEnable()
    {
        _button.onClick.AddListener(OnClickHandler);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClickHandler);
    }
    public void ActivateTower()
    {
        TowerView.GetComponentInParent<CellView>().State = CellState.HasTower;
        TowerView.gameObject.SetActive(true);
    }
    private void OnClickHandler()
    {
        OnTowerButtonClick?.Invoke();
    }
}
