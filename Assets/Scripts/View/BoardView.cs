using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardView : MonoBehaviour
{
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private BoardScriptableObject _settings;
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }
    public BoardScriptableObject BoardSettings
    {
        get
        {
            if (_settings.RowNumber > 2 && _settings.RowNumber < 27)
            {
                return _settings;
            }
            else
            {
                Debug.Log("�������� ���������� ������ �� 3 �� 26");
                return null;
            }
        }
        set => _settings = value;
    }
}
