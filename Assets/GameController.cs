using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameOverEvent : UnityEvent<TileState>
{

}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameOverEvent gameOverEvent = new GameOverEvent();
    //public UnityEvent jumpEvent = new UnityEvent();
    //public UnityEvent fireEvent = new UnityEvent();

    public GameObject tilePrefab;
    private bool isPlayerCross;
    private bool isGameOver;
    private Tile[] tiles;

    // Awake is called before start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("There can only be one game controller.");
        }
        //jumpEvent.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateBoard();
        isPlayerCross = true;
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

    public void MakeMove(TileState tileState, int tileId)
    {
        if (!isGameOver && ((tileState == TileState.Cross && isPlayerCross) || (tileState == TileState.Circle && !isPlayerCross)))
        {
            if (tiles[tileId].state == TileState.Empty)
            {
                tiles[tileId].SetState(tileState);
                isPlayerCross = !isPlayerCross;
                if (IsWinner(tileState))
                {
                    isGameOver = true;
                    print("Winner is " + tileState);
                    gameOverEvent.Invoke(tileState);
                }
            }
        }
    }

    public bool IsWinner(TileState tileState)
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
        //foreach (Tuple<int, int, int> combination in combinations)
        //{
        //    if (tiles[combination.Item1].state == tileState && tiles[combination.Item2].state == tileState && tiles[combination.Item3].state == tileState)
        //        return true;
        //}
        //return false;
        //
        //return combinations.Any(x => {
        //    bool result = tiles[x.Item1].state == tileState && tiles[x.Item2].state == tileState && tiles[x.Item3].state == tileState;
        //    return result;
        //});
        //
        return combinations.Any(x => tiles[x.Item1].state == tileState && tiles[x.Item2].state == tileState && tiles[x.Item3].state == tileState);
    }
}
