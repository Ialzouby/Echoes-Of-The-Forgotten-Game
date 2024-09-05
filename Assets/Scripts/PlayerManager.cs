using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TMP_Text playerNameText;
    public GameObject[] characterSprites; // Array of character sprite GameObjects

    private void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);

        playerNameText.text = playerName;
        for (int i = 0; i < characterSprites.Length; i++)
        {
            characterSprites[i].SetActive(i == selectedCharacterIndex);
        }
    }
}

