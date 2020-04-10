using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject finalPanel;
    public GameObject textCircle;
    public GameObject textCross;
    public GameObject textEmpty;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameController.instance.gameOverEvent.AddListener(OnGameOverEvent);
        //GameController.instance.jumpEvent.AddListener(() => finalPanel.SetActive(true));
    }

    public void OnGameOverEvent(TileState tileState)
    {
        finalPanel.SetActive(true);
        if (tileState == TileState.Circle)
        {
            textCircle.SetActive(true);
            textCross.SetActive(false);
            textEmpty.SetActive(false);
        }
        if (tileState == TileState.Cross)
        {
            textCircle.SetActive(false);
            textCross.SetActive(true);
            textEmpty.SetActive(false);
        }
        if (tileState == TileState.Empty)
        {
            textCircle.SetActive(false);
            textCross.SetActive(false);
            textEmpty.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
