using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _costText;
    [SerializeField] private TMPro.TMP_Text _damageUpgradeText;
    [SerializeField] private TMPro.TMP_Text _radiusUpgradeText;
    [SerializeField] private TMPro.TMP_Text _speedUpgradeText;
    [SerializeField] private Button _button;
  
    public TowerView ActiveView { get; set; }
    public event Action<UpgradeButton, TowerView> OnUpgradeButtonClick = delegate { };
    public TMPro.TMP_Text CostText
    {
        get => _costText;
        set => _costText = value;
    }
    public TMPro.TMP_Text DamageUpgradeText
    {
        get => _damageUpgradeText;
        set => _damageUpgradeText = value;
    }
    public TMPro.TMP_Text RadiusUpgradeText
    {
        get => _radiusUpgradeText;
        set => _radiusUpgradeText = value;
    }
    public TMPro.TMP_Text SpeedUpgradeText
    {
        get => _speedUpgradeText;
        set => _speedUpgradeText = value;
    }
    public UpgradeSO UpgradeConfig { get; set; }
    
    private void OnEnable()
    {
        _button.onClick.AddListener(delegate
        {
            OnUpgradeButtonClick?.Invoke(this, ActiveView);
        });
    }
}
