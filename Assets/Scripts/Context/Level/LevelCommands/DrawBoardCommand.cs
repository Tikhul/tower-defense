using context.level;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoardCommand : Command
{
    [Inject] public GameObject BoardParent { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();
    public override void Execute()
    {
        DrawBoard();
    }

    private void DrawBoard()
    {
        BoardPartsPrototype prototype = new StandardPartPrototype();
        int rowNumber = GameModel.Board.Settings.RowNumber;
        float fullSideScale = GameModel.Board.Settings.ParentPanel.transform.localScale.x;
        float smallSideScale = fullSideScale / rowNumber * 10;
        float moveWidth = GameModel.Board.Settings.ParentPanel.GetComponent<BoxCollider>().size.x
            / rowNumber / 10;

        for (int r = 0; r < rowNumber; r++)
        {
            GameObject row = prototype.Clone(GameModel.Board.Settings.Rows, BoardParent,
                Vector3.one, new Vector3(0, 0, moveWidth));

            for (int b = 0; b < rowNumber; b++)
            {
                GameObject button = prototype.Clone(GameModel.Board.Settings.ButtonExample, row,
                    new Vector3(smallSideScale, 0.5f, smallSideScale), 
                    new Vector3(moveWidth, 0, 0));

                prototype.AdjustButtonPosition(button, b, rowNumber);
                prototype.AdjustRowPosition(row, button, r, moveWidth);
 
                injectionBinder.GetInstance<FillCellListSignal>().Dispatch(button, StaticName.Alphabet[b], r);
            }
        }
    }
}
