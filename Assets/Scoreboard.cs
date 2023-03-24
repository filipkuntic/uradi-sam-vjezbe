using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] GameObject scoreboardItemPrefab;

     void Start()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardPlayer(player);
        }
    }

    void AddScoreboardPlayer(Player player)
    {
        ScoreboardItem item = Instantiate(scoreboardItemPrefab, container).GetComponent<ScoreboardItem>();
        item.Initialize(player);
    }
}
