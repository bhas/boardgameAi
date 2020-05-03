using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared
{
    public class Ai : MonoBehaviour
    {
        public PlayerEnum player;
        bool isTurn;

        // Awake is called before start
        void Awake()
        {
            GameController.gameController.changeTurnEvent.AddListener(OnChangeTurnEvent);
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            //if (isTurn)
            //{
            //    GameController.gameController.MakeMove(player, Random.Range(0, 9));
            //}
        }

        private void OnChangeTurnEvent(PlayerEnum player)
        {
            if (this.player == player)
            {
                BoardState boardState = GameController.gameController.GetBoardState();
                int i = Random.Range(0, boardState.openIds.Length);
                GameController.gameController.MakeMove(player, boardState.openIds[i]);
            }
        }
    }
}
