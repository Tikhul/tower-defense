using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class BoardPartsPrototype : MonoBehaviour
{
    //[Inject] GameModel GameModel { get; set; }

    //private int _rowNumber;
    //private float _parentPanelSide;
    //private float _buttonWidth;
    //private GameObject _parentPanel;
    //private GameObject _boardParent;
    //private GameObject _rows;
    //private GameObject _columns;
    //private GameObject _buttonExample;
    //public int RowNumber
    //{
    //    get => _rowNumber = GameModel.Board.Settings.RowNumber;
    //    set => _rowNumber = value;
    //}
    //public float ParentPanelSide
    //{
    //    get => _parentPanelSide = GameModel.Board.Settings.ParentPanel.GetComponent<RectTransform>().sizeDelta.x;
    //    set => _parentPanelSide = value;
    //}
    //public float ButtonWidth
    //{
    //    get => _buttonWidth = _parentPanelSide / GameModel.Board.Settings.RowNumber;
    //    set => _buttonWidth = value;
    //}
    //public GameObject ParentPanel
    //{
    //    get => _parentPanel = GameModel.Board.Settings.ParentPanel;
    // //   set => _parentPanel = value;
    //}
    //public GameObject Rows
    //{
    //    get => _rows = GameModel.Board.Settings.Rows;
    //    set => _rows = value;
    //}
    //public GameObject Columns
    //{
    //    get => _columns = GameModel.Board.Settings.Columns;
    //    set => _columns = value;
    //}
    //public GameObject ButtonExample
    //{
    //    get => _buttonExample = GameModel.Board.Settings.ButtonExample;
    //    set => _buttonExample = value;
    //}
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