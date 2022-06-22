using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellButton : MonoBehaviour
// Кнопка для поля
{
    private int _cellInt;
    private char _cellChar;
    public CellState State { get; set; } = CellState.Empty;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _buttonElement;
    [SerializeField] private AllTowersView _towers;
    public int CellInt
    {
        get => _cellInt;
        set => _cellInt = value;
    }
    public char CellChar
    {
        get => _cellChar;
        set => _cellChar = value;
    }
    public TMP_Text ButtonText
    {
        get => _buttonText;
        set => _buttonText = value;
    }
    public Button ButtonElement
    {
        get => _buttonElement;
        set => _buttonElement = value;
    }
}

public enum CellState
{
    Empty,
    HasTower,
    EnemyWay
}