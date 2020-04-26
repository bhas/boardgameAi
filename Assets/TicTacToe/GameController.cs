using Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace TicTacToe
{
    [System.Serializable]
    public class GameOverEvent : UnityEvent<PlayerEnum?> { }
    public class ChangeTurnEvent : UnityEvent<PlayerEnum> { }

    public class GameController : MonoBehaviour
    {
        public static GameController gameController;

        public GameOverEvent gameOverEvent = new GameOverEvent();
        public ChangeTurnEvent changeTurnEvent = new ChangeTurnEvent();

        public GameObject tilePrefab;
        private PlayerEnum playerTurn;
        private bool isGameOver;
        private Tile[] tiles;

        // Awake is called before start
        void Awake()
        {
            if (gameController == null)
            {
                gameController = this;
            }
            else
            {
                throw new Exception("There can only be one game controller.");
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            CreateBoard();
            changeTurnEvent.Invoke(PlayerEnum.Player1);
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
                    //GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity);
                    GameObject obj = Instantiate(tilePrefab, new Vector3(scale.x * i * 1.1f, scale.y * j * 1.1f, scale.z), Quaternion.identity);
                    Tile tile = obj.GetComponent<Tile>();
                    //tile.SetState(null);
                    tile.id = id;
                    tiles[id++] = tile;
                }
            }
        }

        public bool MakeMove(PlayerEnum player, int tileId)
        {
            // check if is invalid move
            if (isGameOver || player != playerTurn || tiles[tileId].state != null)
                return false;


            tiles[tileId].SetState(player);
            if (IsWinner(player))
            {
                isGameOver = true;
                gameOverEvent.Invoke(player);
            }
            else if (tiles.All(x => x.state != null))
            {
                isGameOver = true;
                gameOverEvent.Invoke(null);
            }

            ChangeTurn(player);

            return true;
        }

        private void ChangeTurn(PlayerEnum player)
        {
            if (playerTurn == PlayerEnum.Player1)
            {
                playerTurn = PlayerEnum.Player2;
            }
            else
            {
                playerTurn = PlayerEnum.Player1;
            }
            changeTurnEvent.Invoke(playerTurn);
        }

        public bool IsWinner(PlayerEnum player)
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
            return combinations.Any(x => tiles[x.Item1].state == player && tiles[x.Item2].state == player && tiles[x.Item3].state == player);
        }
    }
}
