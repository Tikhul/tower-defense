using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellButton : MonoBehaviour, ICellButton
// Кнопка для поля
{
    private int _cellInt;
    private char _cellChar;
    public CellState State { get; set; } = CellState.Empty;
    [SerializeField] private TMP_Text _buttonText;
    [SerializeField] private Button _buttonElement;
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

    public event System.Action<CellButton> OnPlayerClick = delegate { };

    public void CellClicked()
    {
        throw new System.NotImplementedException();
    }

    public void CellTaken(ICellButton chosenButton)
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {

    }
}

public interface ICellButton
{
    void CellClicked();
    void CellTaken(ICellButton chosenButton);
}

public enum CellState
{
    Empty,
    HasTower,
    EnemyWay
}