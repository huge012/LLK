using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    #region Singleton
    private static UIManager instance;
    public static UIManager GetInstance() {
        if (!instance) {

            instance = FindObjectOfType<UIManager>();
        }
        return instance;
    }
    #endregion

    public Text timeText;
    public Text countText;
    public Text win;
    public Image chargeBar;
    public Image block;

    public GameObject endGame;


    private void Update() {

        timeText.text = ((int)GameManager.GetInstance().timeCount / 60).ToString() +" : " + (GameManager.GetInstance().timeCount % 60).ToString();
        countText.text = GameManager.GetInstance().count.ToString() + "";
        chargeBar.fillAmount = Item.GetInstance().skillCharge / 120f;
    }


    public void EndGame(string _team) {

        endGame.SetActive(true);
        
        if (_team == "Blue") {

            win.text = "수비팀 승리";
        }
        else if (_team == "Red") {

            win.text = "공격팀 승리";
        }
    }
}
