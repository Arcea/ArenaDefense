using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public Image image;
    public Text text;

    private List<Character> characters;

    private Character currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        characters = new List<Character>()
        {
            new Character("url", "informatica"),
            new Character("url", "technische informatica"),
        };

        currentCharacter = characters[0];
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = currentCharacter.image;
        text.text = currentCharacter.text;
    }

    public void NextSlide()
    {
        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);

        Debug.Log(currentIndex);
        Debug.Log(currentIndex + 1);
        if(currentIndex + 1 < characters.Count)
        {
            Debug.Log("Next slide");
            currentCharacter = characters[currentIndex + 1];
        }
    }

    public void PreviousSlide()
    {
        int currentIndex = characters.FindIndex(c => c.text == currentCharacter.text);

        Debug.Log(currentIndex);
        Debug.Log(currentIndex - 1);
        if (currentIndex - 1 >= 0)
        {
            Debug.Log("Previous slide");
            currentCharacter = characters[currentIndex - 1];
        }
    }
}

public struct Character
{
    public Sprite image;
    public string text;

    public Character(string image, string text)
    {
        this.image = Resources.Load<Sprite>(image);
        this.text = text;
    }
}
