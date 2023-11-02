using System;
using UnityEngine;

public class BoardView : BaseView
{
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private GameObject _cameraPosition;

    private BoardPartsPrototype _prototype = new StandardPartPrototype();
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        Camera _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mainCamera.orthographic = false;
        _mainCamera.transform.position = _cameraPosition.transform.position;
        _mainCamera.transform.rotation = _cameraPosition.transform.rotation;
    }

    public void DrawCell(CellData data)
    {
       // BoardPartsPrototype prototype = new StandardPartPrototype();
        // int rowNumber = gameModel.Board.Settings.RowNumber;
        // float fullSideScale = gameModel.Board.Settings.ParentPanel.transform.localScale.x;
        // float smallSideScale = fullSideScale / rowNumber * 10;
        // float moveWidth = gameModel.Board.Settings.ParentPanel.GetComponent<BoxCollider>().size.x
        //                   / rowNumber / 10;
        //
        // for (int r = 0; r < rowNumber; r++)
        // {
        //     GameObject row = prototype.Clone(gameModel.Board.Settings.Rows, BoardParent,
        //         Vector3.one, new Vector3(0, 0, moveWidth));
        //
        //     for (int b = 0; b < rowNumber; b++)
        //     {
        //         GameObject button = prototype.Clone(gameModel.Board.Settings.ButtonExample, row,
        //             new Vector3(smallSideScale, 0.5f, smallSideScale), 
        //             new Vector3(moveWidth, 0, 0));
        //
        //         prototype.AdjustButtonPosition(button, b, rowNumber);
        //         prototype.AdjustRowPosition(row, button, r, moveWidth);
        //     }
        // }
    }
}
