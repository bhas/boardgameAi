using Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Connect4
{
    public class GameController : MonoBehaviour
    {
        public GameObject tilePrefab;
        private Tile[] tiles;

        // Start is called before the first frame update
        void Start()
        {
            CreateBoard();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void CreateBoard()
        {
            tiles = new Tile[6 * 7];
            Vector3 scale = tilePrefab.transform.localScale;
            int id = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    //GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity);
                    GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity);
                    Tile tile = obj.GetComponent<Tile>();
                    tile.id = id;
                    tiles[id++] = tile;
                }
            }
        }
    }
}
