using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndDetection : MonoBehaviour
{
    public GameObject player;
    public GameObject EndScreen;
    public TextMeshProUGUI FinalScore;
    public PlayerStats playerStats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FinalScore.text = "Your final score is  " + playerStats.Score;
            EndScreen.SetActive(true);
            Destroy(player);
        }
    }
}
