using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownScript : MonoBehaviour
{
    public static float currTime;
    public float startTime = 5;

    [SerializeField] GameObject GameOver_Panel;

    [SerializeField] Text countdownText;

    void Start()
    {
        currTime = startTime;
    }

    void Update()
    {
        currTime -= 1 * Time.deltaTime;
        countdownText.text = currTime.ToString("0");

        if(currTime <= 0)
        {
            currTime = 0;
            GameOver();
        }
    }

    public void ResetTimer()
    {
        currTime = startTime;
    }

    public void GameOver()
    {
        GameOver_Panel.SetActive(true);
    }

}
