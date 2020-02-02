using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToFinish = 300;
    [SerializeField] Text text = null;
    [SerializeField] GameObject lose;

    void Update()
    {
        timeToFinish -= Time.deltaTime;
        if (text != null){
            text.text = "Book Club Friends \nArrive in: " + (int)timeToFinish;
        }

        if (timeToFinish <= 0){
            LevelManager levelManager = FindObjectOfType<LevelManager>();
            if (levelManager != null){
                levelManager.LoadNextLevel();
            }
            else {
                lose.SetActive(true);
            }
        }
    }
}
