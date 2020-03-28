using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tilePrefab;
    private int currentPlayerId = 1;
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
        tiles = new Tile[9];
        Vector3 scale = tilePrefab.transform.localScale;
        int id = 0;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity);
                Tile tile = obj.GetComponent<Tile>();
                tile.SetState(TileState.Empty);
                tile.id = id;
                tiles[id++] = tile;
            }
        }
    }

    public void MakeMove(int playerid, int tileid)
    {
        if (playerid == currentPlayerId)
        {
            tiles[tileid].SetState(playerid == 1 ? TileState.Cross : TileState.Circle);
        }
    }
}
