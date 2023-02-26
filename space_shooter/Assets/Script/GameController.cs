using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public float xMinMax;
    public float zMin;

    public GameObject prop;
    public int count;
    public float startWait;
    public float dropStone;
    public float waitRound;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        score =0;
        gameOver=restart=false;
        scoreText.text="Score: 0";
        restartText.text="";
        gameOverText.text="";

        // vi la ham yield nen phai su dung them lenh
        StartCoroutine(Waves());
    }

    void Update() 
    {
        if (restart && Input.GetKeyDown(KeyCode.R))    
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // de dung yield thi ham phai doi tu void -> IEnumerator
    IEnumerator Waves()
    {
        while(true) // qua round, het 1 round den round khac de stone roi xuong
        {
            // chuan bi trc khi stone roi
            yield return new WaitForSeconds(startWait);

            // nhieu stone roi
            for (int i =0; i<count; i++)
            {
                Instantiate(prop, new Vector3(Random.Range(-xMinMax,xMinMax), 0, zMin), Quaternion.identity);
                yield return new WaitForSeconds(dropStone);

            }
            
            // wait round
            yield return new WaitForSeconds(waitRound);

            // game over - ko rot stone nua, muon tiep tuc an R
            if (gameOver)
            {
                restart=true;
                restartText.text="Press 'R' to restart";
                break;
            }
        }
        
    }

    public void addScore(int sc)
    {
        score+=sc;
        scoreText.text = "Score: "+score;
    }
    public void gameRaDi()
    {
        gameOverText.text="GAME OVER!";
        gameOver = true;
        restart = true;
        restartText.text="Press 'R' to restart";
    }


}
