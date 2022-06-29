using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _towerButtonText;
    [SerializeField] private Image _towerButtonImage;
    [SerializeField] private Button _button;
    public TowerView TowerView { get; set; }
    public event Action<TowerButton> OnTowerButtonClick = delegate { };
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
    private void OnEnable()
    {
        _button.onClick.AddListener(delegate
        {
            OnTowerButtonClick?.Invoke(this);
        });
    }

    public void ActivateTower()
    {
        Debug.Log("Activate Tower");
        TowerView.GetComponentInParent<CellButton>().State = CellState.HasTower;
        TowerView.gameObject.SetActive(true);
    }
}
