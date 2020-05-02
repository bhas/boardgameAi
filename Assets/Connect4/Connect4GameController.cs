using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Connect4
{
    public class Connect4GameController : GameController
    {
        protected override void CreateBoard()
        {
            board.Create(6, 7);
        }

        protected override bool IsEmptyTile(int tileId)
        {
            throw new NotImplementedException();
        }

        protected override bool IsWinner(PlayerEnum player)
        {
            throw new NotImplementedException();
        }
    }
}
