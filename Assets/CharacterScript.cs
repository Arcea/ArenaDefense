﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Image image;
    public Text text;
    public Text subText;
    public Image checkMark;

    private List<Character> characters;
    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        checkMark.enabled = false;
        characters = new List<Character>()
        {
            new Character("Programmer", "Sloth", "Informatica"),
            new Character("Mechatronica", "Parody", "Mechatronica"),
            new Character("ElectroTechniek", "Nikola", "Electro Techniek"),
            new Character("TechnischeInformatica", "Cipher", "Technische Informatica")
        };

        currentCharacter = new Character("Programmer", "Press A to join", "");
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = currentCharacter.image;
        text.text = currentCharacter.text;
        subText.text = currentCharacter.subText;
    }

    public void Init()
    {
        currentCharacter = characters[0];
        image.enabled = true;
        image.color = new Color(255, 255, 255, 1);
    }

    public Character GetCharacter()
    {
        return currentCharacter;
    }

    public void ToggleReady(bool ready)
    {
        checkMark.enabled = ready;
    }

    public void NextSlide()
    {
        if (checkMark.enabled) return;

        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);
        if(currentIndex + 1 < characters.Count)
        {
            currentCharacter = characters[currentIndex + 1];
        }
        else
        {
            currentCharacter = characters[0];
        }
    }

    public void PreviousSlide()
    {
        if (checkMark.enabled) return;

        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);
        if (currentIndex - 1 >= 0)
        {
            currentCharacter = characters[currentIndex - 1];
        }
        else
        {
            currentCharacter = characters[characters.Count - 1];
        }

    }
}

public struct Character
{
    public Sprite image;
    public string text;
    public string subText;

    public Character(string image, string text, string subText)
    {
        this.image = Resources.Load<Sprite>(image);
        this.text = text;
        this.subText = subText;
    }
}