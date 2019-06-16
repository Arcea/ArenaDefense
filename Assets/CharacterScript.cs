using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Image image;
    public Text text;
    public Text subText;
    public Text lore;
    public ScrollRect loreScroll;
    public Image checkMark;

    private List<Character> characters;
    private Character currentCharacter;
    private bool loreIsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        checkMark.enabled = false;
        loreScroll.transform.parent.gameObject.SetActive(false);

        characters = new List<Character>()
        {
            new Character("Programmer", "Sloth", "Informatica", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla volutpat dapibus neque, in tincidunt odio laoreet vel. Vestibulum condimentum leo id dictum viverra. Nullam velit turpis, porta a viverra sed, viverra in tortor. Proin turpis ex, rutrum et justo sit amet, tempor vehicula felis. Ut sit amet congue orci. Vestibulum eu vestibulum dolor. Sed auctor, est vel tristique eleifend, magna ante aliquet orci, eu volutpat elit neque non metus. Quisque condimentum justo enim. Vestibulum a interdum justo, sed efficitur lorem. Mauris id gravida nibh. Vivamus lacinia, arcu et viverra sollicitudin, enim nunc interdum libero, nec tristique est ante ullamcorper est. Mauris justo ligula, ultricies vitae iaculis quis, interdum ac elit. Aliquam suscipit facilisis urna nec euismod."),
            new Character("Mechatronica", "Parody", "Mechatronica", "Vivamus ac condimentum dolor, at eleifend lorem. Donec non lobortis velit, sit amet consequat mi. Donec dignissim felis at tellus tincidunt blandit. In ac risus tincidunt, tincidunt metus eu, eleifend turpis. Suspendisse ac elit eu lorem mattis commodo sit amet sagittis eros. Praesent vestibulum gravida interdum. Praesent nec metus at nisl porttitor efficitur non quis nisi. Mauris pretium ante sit amet nibh dapibus, ut tristique ante mollis. Pellentesque eu enim cursus nisi dapibus congue quis eget enim. Nullam eget vestibulum nulla. Vestibulum pulvinar consequat pretium."),
            new Character("ElectroTechniek", "Nikola", "Electro Techniek", "Fusce dapibus eget augue vitae tristique. Integer consequat quis lectus in sodales. Fusce hendrerit, turpis a ultrices pretium, massa ex lacinia magna, auctor tincidunt tellus quam vel justo. Fusce vehicula, leo eget sagittis scelerisque, magna quam vulputate nulla, vitae mollis magna nisi sed metus. Integer id dapibus lacus. Aliquam non euismod justo, tincidunt tincidunt odio. Phasellus posuere vehicula sapien, in gravida elit eleifend et. Quisque dui nisi, porttitor eget massa sit amet, dictum lobortis nisl."),
            new Character("TechnischeInformatica", "Cipher", "Technische Informatica", "Curabitur libero nisi, elementum semper elit sit amet, blandit aliquam nisi. Sed eget nisi in nisl mollis pharetra fermentum ut nisl. Donec tristique velit et justo congue pulvinar. Sed vehicula placerat purus eu mollis. Phasellus at dui eget enim pellentesque ornare in hendrerit neque. Mauris finibus varius semper. Ut tincidunt, felis at condimentum consectetur, magna leo venenatis sapien, ac ornare mi ante id ex. In euismod odio orci, sit amet finibus velit elementum ut. Ut sit amet nunc ultricies, pretium libero eu, euismod quam. In facilisis quis odio sed lacinia. Fusce faucibus nibh nibh, et semper lacus egestas ac."),
            new Character("Werktuigbouwkunde", "Bullseye", "Werktuigbouwkunde", "Maecenas in sodales neque. Praesent ut vehicula est. Nulla consectetur sodales libero eu mattis. Mauris vel placerat ipsum. Duis sed tempus tellus. Fusce quam tortor, cursus iaculis viverra vitae, faucibus sit amet nisi. Nunc suscipit, ante sed iaculis vehicula, metus libero dictum eros, malesuada lacinia elit dui at leo. Curabitur non dui nec ante euismod tempor at a ligula. Vivamus dapibus suscipit ex, ut posuere nunc aliquet quis. Aenean vel turpis et purus varius fringilla et eu sem. Phasellus efficitur porttitor nunc. Donec ullamcorper lorem et elit aliquet sodales. Nulla pulvinar leo sit amet rhoncus suscipit.")
        };

        currentCharacter = new Character("Programmer", "Press A to join", null, null);
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = currentCharacter.image;
        text.text = currentCharacter.text;
        subText.text = currentCharacter.subText;
        lore.text = currentCharacter.lore;
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

    internal bool ToggleLore()
    {
        loreIsActive = !loreIsActive;
        loreScroll.transform.parent.gameObject.SetActive(loreIsActive);
        return loreIsActive;
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

        loreScroll.verticalNormalizedPosition = 1;
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

        loreScroll.verticalNormalizedPosition = 1;
    }

    internal void ScrollLoreUp()
    {
        loreScroll.verticalNormalizedPosition = 0;
    }

    internal void ScrollLoreDown()
    {
        loreScroll.verticalNormalizedPosition = 1;
    }
}

public struct Character
{
    public Sprite image;
    public string text;
    public string subText;
    internal string lore;

    public Character(string image, string text, string subText, string lore)
    {
        this.image = Resources.Load<Sprite>(image);
        this.text = text;
        this.subText = subText;
        this.lore = lore;
    }
}
