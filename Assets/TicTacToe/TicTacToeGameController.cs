using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TicTacToe
{
    public class TicTacToeGameController : GameController
    {
        protected override bool IsWinner(PlayerEnum player)
        {
            List<Tuple<int, int, int>> combinations = new List<Tuple<int, int, int>>
        {
            new Tuple<int, int, int>(0,1,2),
            new Tuple<int, int, int>(3,4,5),
            new Tuple<int, int, int>(6,7,8),
            new Tuple<int, int, int>(0,3,6),
            new Tuple<int, int, int>(1,4,7),
            new Tuple<int, int, int>(2,5,8),
            new Tuple<int, int, int>(0,4,8),
            new Tuple<int, int, int>(2,4,6)
        };
            return combinations.Any(x => board.tiles[x.Item1].state == player && board.tiles[x.Item2].state == player && board.tiles[x.Item3].state == player);
        }

        protected override bool IsEmptyTile(int tileId)
        {
            return board.tiles[tileId].state == null;
        }

        protected override void CreateBoard()
        {
            board.Create(3, 3);
        }
    }
}
