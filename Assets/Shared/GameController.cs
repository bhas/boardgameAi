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

        public abstract BoardState GetBoardState();
        protected abstract void CreateBoard();
        protected abstract bool IsWinner(int tileId, PlayerEnum player);
        protected abstract bool IsEmpty(int tileId);

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
            if (isGameOver || player != playerTurn || !IsEmpty(tileId))
                return false;


            board.GetTile(tileId).SetState(player);
            if (IsWinner(tileId, player))
            {
                isGameOver = true;
                gameOverEvent.Invoke(player);
            }
            else if (board.IsFull())
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