using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BoardPartsPrototype : BoardLibraryModel
{
    private float _rowNumber;
    private float _parentPanelSide;
    private float _buttonWidth;
    private GameObject _parentPanel;
    private GameObject _rows;
    private GameObject _columns;
    private GameObject _buttonExample;
    public int RowNumber
    {
        get => BoardSettings.RowNumber;
        set => BoardSettings.RowNumber = value;
    }
    public float ParentPanelSide
    {
        get => _parentPanelSide = BoardSettings.ParentPanel.GetComponent<RectTransform>().sizeDelta.x;
        set => _parentPanelSide = value;
    }
    public float ButtonWidth
    {
        get => _buttonWidth = _parentPanelSide / BoardSettings.RowNumber;
        set => _buttonWidth = value;
    }
    public GameObject ParentPanel
    {
        get => _parentPanel = BoardSettings.ParentPanel;
        set => _parentPanel = value;
    }
    public GameObject Rows
    {
        get => _rows = BoardSettings.Rows;
        set => _rows = value;
    }
    public GameObject Columns
    {
        get => _columns = BoardSettings.Columns;
        set => _columns = value;
    }
    public GameObject ButtonExample
    {
        get => _buttonExample = BoardSettings.ButtonExample;
        set => _buttonExample = value;
    }
    public abstract GameObject Clone(GameObject objToCreate, GameObject parent, float width, float height);
}
class StandardPartPrototype : BoardPartsPrototype
{
    public override GameObject Clone(GameObject objToCreate, GameObject parent, float width, float height)
    {
        GameObject newObject = Instantiate(objToCreate);
        newObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
        newObject.transform.SetParent(parent.transform);
        newObject.transform.localScale = new Vector3(1, 1, 1);
        newObject.transform.localPosition = newObject.transform.position;
        return newObject;
    }
}