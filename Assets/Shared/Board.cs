using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class Board : MonoBehaviour
    {
        public int rows;
        public int cols;
        public GameObject tilePrefab;
        public Tile[] tiles;

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
}