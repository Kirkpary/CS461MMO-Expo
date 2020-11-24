﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CharacterSelection : MonoBehaviour
{
    // All the characters options goes into this list
    private List<GameObject> characters = new List<GameObject>();
    private int selectedCharacter = 0;

    private void Start()
    {
        var temp = Resources.LoadAll("Avatars", typeof(GameObject)).Cast<GameObject>();
        foreach (GameObject character in temp)
        {
            GameObject newPlayer = Instantiate(character, gameObject.transform);
            newPlayer.name = character.name;
            newPlayer.SetActive(false);
            characters.Add(newPlayer);
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Count;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Count;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetString("selectedCharacter", characters[selectedCharacter].name);
        Debug.LogFormat("The selectedCharacter int is {0}", PlayerPrefs.GetString("selectedCharacter"));
    }
}
