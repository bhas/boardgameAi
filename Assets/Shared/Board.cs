using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shared
{
    public class Board : MonoBehaviour
    {
        public int rows;
        public int cols;
        public GameObject tilePrefab;
        private Tile[] tiles;

        public BoardState GetBoardState(Func<int, bool> isEmpty)
        {
            BoardState boardState = new BoardState();
            boardState.states = tiles.Select(x => x.state).ToArray();
            boardState.openIds = tiles.Where(x => isEmpty(x.id)).Select(x => x.id).ToArray();
            return boardState;
        }

        public Tile GetTile(int tileId)
        {
            return tileId >= 0 && tileId < tiles.Length ? tiles[tileId] : null;
        }

        public Tile GetNeighbour(int tileId, NeighbourEnum neighbour)
        {
            switch (neighbour)
            {
                case NeighbourEnum.Top:
                    return GetTile(tileId + cols);
                case NeighbourEnum.Bottom:
                    return GetTile(tileId - cols);
                case NeighbourEnum.Left:
                    return tileId % cols == 0 ? null : GetTile(tileId - 1);
                case NeighbourEnum.Right:
                    return (tileId + 1) % cols == 0 ? null : GetTile(tileId + 1);
                case NeighbourEnum.BottomLeft:
                    return tileId % cols == 0 ? null : GetTile(tileId - cols - 1);
                case NeighbourEnum.BottomRight:
                    return (tileId + 1) % cols == 0 ? null : GetTile(tileId - cols + 1);
                case NeighbourEnum.TopLeft:
                    return tileId % cols == 0 ? null : GetTile(tileId + cols - 1);
                case NeighbourEnum.TopRight:
                    return (tileId + 1) % cols == 0 ? null : GetTile(tileId + cols + 1);
                default:
                    throw new NotImplementedException();
            }
        }

        public bool IsFull()
        {
            return tiles.All(x => x.state != null);
        }

        public void Create(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            tiles = new Tile[rows * cols];
            Vector3 scale = tilePrefab.transform.localScale;
            int id = 0;
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < cols; i++)
                {
                    GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity, transform);
                    obj.name = "Tile " + id.ToString();
                    Tile tile = obj.GetComponent<Tile>();
                    //tile.SetState(null);
                    tile.id = id;
                    tiles[id++] = tile;
                }
            }
        }
    }

    public enum NeighbourEnum
    {
        Bottom,
        Top,
        Left,
        Right,
        BottomLeft,
        BottomRight,
        TopLeft,
        TopRight,
    }
}