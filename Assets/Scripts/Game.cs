using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore;
    private int[] score = new int[2];

    bool playingGame;

    public int[] Score { get => score; set => score = value; }
    public bool PlayingGame { get => playingGame; set => playingGame = value; }


    private void OnStart()
    {
        playingGame = true;
    }

    public void IncreaseScore(int player)
    {
        score[player]++;
        textScore.text = score[0] + " - " + score[1];
    }
}
