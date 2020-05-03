using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Connect4
{
    public class Connect4GameController : GameController
    {
        public override BoardState GetBoardState()
        {
            return board.GetBoardState(IsEmpty);
        }

        protected override void CreateBoard()
        {
            board.Create(6, 7);
        }

        protected override bool IsEmpty(int tileId)
        {
            Tile tile = board.GetTile(tileId);
            Tile tileBelow = board.GetNeighbour(tileId, NeighbourEnum.Bottom);
            return tile.state == null && (tileBelow == null || tileBelow.state != null);
        }

        protected override bool IsWinner(int tileId, PlayerEnum player)
        {
            Tile tile = board.GetTile(tileId);

            // horizontal
            int count = 1;
            count += CountStates(tile, NeighbourEnum.Left);
            count += CountStates(tile, NeighbourEnum.Right);
            if (count > 3)
                return true;

            // vertical
            count = 1;
            //count += CountStates(tile, NeighbourEnum.Top);
            count += CountStates(tile, NeighbourEnum.Bottom);
            if (count > 3)
                return true;

            // diagonal up from left side (/)
            count = 1;
            count += CountStates(tile, NeighbourEnum.BottomLeft);
            count += CountStates(tile, NeighbourEnum.TopRight);
            if (count > 3)
                return true;

            // diagonal down from left side (\)
            count = 1;
            count += CountStates(tile, NeighbourEnum.TopLeft);
            count += CountStates(tile, NeighbourEnum.BottomRight);
            if (count > 3)
                return true;

            return false;

            //int count = 1;
            //count = 1;
            //count += CountStates(tile, NeighbourEnum.Top) + CountStates(tile, NeighbourEnum.Bottom);
            //if (count < 3)
            //{
            //    count = 1;
            //    count += CountStates(tile, NeighbourEnum.Top) + CountStates(tile, NeighbourEnum.Bottom);
            //}
            //if (count < 3)
            //{
            //    count = 1;
            //    count += CountStates(tile, NeighbourEnum.Top) + CountStates(tile, NeighbourEnum.Bottom);
            //}
            //if (count < 3)
            //{
            //    count = 1;
            //    count += CountStates(tile, NeighbourEnum.Top) + CountStates(tile, NeighbourEnum.Bottom);
            //}
            //return count > 3;
        }

        private int CountStates(Tile tileOrigin, NeighbourEnum direction)
        {
            Tile tile = board.GetNeighbour(tileOrigin.id, direction);
            int count = 0;
            while (tile?.state == tileOrigin.state)
            {
                tile = board.GetNeighbour(tile.id, direction);
                count++;
            }
            return count;
        }
    }
}
