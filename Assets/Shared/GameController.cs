using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TicTacToe;
using UnityEngine;
using UnityEngine.Events;

namespace Shared
{
    [System.Serializable]
    public class GameOverEvent : UnityEvent<PlayerEnum?> { }
    public class ChangeTurnEvent : UnityEvent<PlayerEnum> { }

    public abstract class GameController : MonoBehaviour
    {
        public static GameController gameController;

        public GameOverEvent gameOverEvent = new GameOverEvent();
        public ChangeTurnEvent changeTurnEvent = new ChangeTurnEvent();

        public Board board;
        private PlayerEnum playerTurn;
        private bool isGameOver;

        protected abstract void CreateBoard();
        protected abstract bool IsWinner(PlayerEnum player);
        protected abstract bool IsEmptyTile(int tileId);

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

        // Update is called once per frame
        void Update()
        {

        }

        public bool MakeMove(PlayerEnum player, int tileId)
        {
            // check if is invalid move
            if (isGameOver || player != playerTurn || !IsEmptyTile(tileId))
                return false;


            board.tiles[tileId].SetState(player);
            if (IsWinner(player))
            {
                isGameOver = true;
                gameOverEvent.Invoke(player);
            }
            else if (board.tiles.All(x => x.state != null))
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
    }
}