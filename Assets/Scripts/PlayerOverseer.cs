using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerOverseer : MonoBehaviour
{
    [SerializeField] private Player mainPlayer;
    [SerializeField] private List<Player> AiPlayers = new List<Player>();
    [SerializeField] private GameManager gameManager;
    public bool win = false;

    void Awake()
    {
        Boot();
    }

    /// <summary>
    /// Listen to all players "Dead" event to know exactly when he died
    /// </summary>
    void Boot()
    {
        mainPlayer.Dead.AddListener(PlayersDeadEvent);
        foreach (var item in AiPlayers)
        {
            item.Dead.AddListener(AiDeadEvent);
        }
    }

    /// <summary>
    /// If all AI players dead, then player win
    /// </summary>
    void  AiDeadEvent()
    {
        print(1);
        foreach (var item in AiPlayers)//todo: Rework this
        {
            print(item.gameObject.activeSelf);
            if (item.gameObject.activeSelf) return;
        }

        win = true;
        gameManager.WinGame();
        
    }

    /// <summary>
    /// Player is dead, show UI panel
    /// </summary>
    void PlayersDeadEvent()
    {
        gameManager.LoseGame();
    }
}
