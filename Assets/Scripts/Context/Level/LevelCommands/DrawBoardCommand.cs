using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoardCommand : Command
{
    public override void Execute()
    {
        Debug.Log("DrawBoardCommand");    
    }
}
