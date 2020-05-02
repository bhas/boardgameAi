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
            if (isTurn)
            {
                GameController.gameController.MakeMove(player, Random.Range(0, 9));
            }
        }

        private void OnChangeTurnEvent(PlayerEnum player)
        {
            isTurn = this.player == player;
        }
    }
}
