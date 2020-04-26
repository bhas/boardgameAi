using Shared;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TicTacToe
{
    public class UIController : MonoBehaviour
    {
        public GameObject finalPanel;
        public GameObject textPlayer1;
        public GameObject textPlayer2;
        public GameObject textEmpty;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            GameController.gameController.gameOverEvent.AddListener(OnGameOverEvent);
            //GameController.instance.jumpEvent.AddListener(() => finalPanel.SetActive(true));
        }

        public void OnGameOverEvent(PlayerEnum? winningPlayer)
        {
            finalPanel.SetActive(true);

            textPlayer1.SetActive(winningPlayer == PlayerEnum.Player1);
            textPlayer2.SetActive(winningPlayer == PlayerEnum.Player2);
            textEmpty.SetActive(winningPlayer == null);        
         }

        public void PlayAgain()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
