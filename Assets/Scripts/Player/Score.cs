using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    int score;
    public TextMeshProUGUI displayedValue;
    public PlayerStats player;
    
    void Update()
    {
        score = player.Score;
        displayedValue.text = score.ToString();
    }
}
