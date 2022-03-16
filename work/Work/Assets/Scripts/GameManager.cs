using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Singleton
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType<GameManager>();
        }

        return instance;
    }
    #endregion

    public List<GameObject> player = new List<GameObject>();
    public List<GameObject> redTeam;
    public List<GameObject> blueTeam;

    public float time;
    public float timeCount;
    public int count;

    public bool countdown;


    private void Start() {

        redTeam = new List<GameObject>();
        blueTeam = new List<GameObject>();
        
        

        StartCoroutine(StartCountDown());
    }

    
    private void Update() {

        if (!countdown)
            return;

        Timer();
        Item.GetInstance().SkillCharge();

        if (redTeam.Count <= 0)
            UIManager.GetInstance().EndGame("Blue");
    }


    IEnumerator StartCountDown() {

        while (count > 0) {

            yield return new WaitForSeconds(1f);
            count--;
        }

        UIManager.GetInstance().block.gameObject.SetActive(false);

        for (int i = 0; i < 3; i++) {

            player[i].GetComponent<PersonController>().countCheck = true;
            player[i].transform.Find("Defence").gameObject.SetActive(true);
            blueTeam.Add(player[i]);
        }
            
        for (int i = 3; i < 6; i++) {

            player[i].GetComponent<PersonController>().countCheck = true;
            player[i].transform.Find("Attack").gameObject.SetActive(true);
            redTeam.Add(player[i]);
        }

        countdown = true;
        yield return null;
    }


    private void Timer() {

        if (time >= 180)
            UIManager.GetInstance().EndGame("Blue");
        else {

            time += Time.deltaTime;
        }
        timeCount = Mathf.FloorToInt(time);
    }


    #region Player Tracking
    private const string PLAYER_ID_PREFIX = "Player ";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer(string _netID, Player _player) {

        string _playerID = "Player " + _netID;

        players.Add(_playerID, _player);

        _player.transform.name = _playerID;
    }

    public static void UnRegisterPlayer(string _playerID) {

        players.Remove(_playerID);
    }

    public static Player GetPlayer(string _playerID) {

        return players[_playerID];
    }
    #endregion
}
