using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoardCommand : Command
{
    [Inject] public GameObject boardParent { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();
    public override void Execute()
    {
        DrawBoard();
    }

    private void DrawBoard()
    {
        BoardPartsPrototype prototype = new StandardPartPrototype();
        float _parentPanelSide = GameModel.Board.Settings.ParentPanel.GetComponent<RectTransform>().sizeDelta.x;
        
        GameObject boardPanel = prototype.Clone(GameModel.Board.Settings.ParentPanel, boardParent,
            _parentPanelSide, _parentPanelSide);

        GameObject row = prototype.Clone(GameModel.Board.Settings.Rows, boardPanel,
            _parentPanelSide, _parentPanelSide);

        for (int r = 0; r < GameModel.Board.Settings.RowNumber; r++)
        {
            GameObject column = prototype.Clone(GameModel.Board.Settings.Columns, row,
                _parentPanelSide / GameModel.Board.Settings.RowNumber,
                _parentPanelSide);

            for (int b = 0; b < GameModel.Board.Settings.RowNumber; b++)
            {
                GameObject button = prototype.Clone(GameModel.Board.Settings.ButtonExample, column,
                    _parentPanelSide / GameModel.Board.Settings.RowNumber,
                    _parentPanelSide / GameModel.Board.Settings.RowNumber);
                
                injectionBinder.GetInstance<FillCellListSignal>().Dispatch(button, StaticName.Alphabet[b], r);
            }
        }
    }
}
