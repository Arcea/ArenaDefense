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
            new Character("Programmer", "Sloth", "Informatica", $"Primary: Laser Gun (Piercing maar minder damage){Environment.NewLine}Ability: Artifacting (het plaatsen van een screenglitch, zorgt voor damage over-time){Environment.NewLine}Ultimate: Hacken (damage boost voor team){Environment.NewLine}{Environment.NewLine}Ambitie: Wil professioneel Mendix developer worden zodra hij afgestudeerd is.{Environment.NewLine}Likes: Redbull, projecten, gamen{Environment.NewLine}Dislikes: Deadlines, vroeg opstaan{Environment.NewLine}{Environment.NewLine}Backstory: Toen ‘het ongeluk’ gebeurde was Informaticus druk bezig met zijn Mendix huiswerk te perfectioneren wat hij belangrijker vond dan naar zijn les professionele vaardigheden toe te gaan. Onwetend wat er gebeurd was op school werd de schokkende realiteit later bekend gemaakt. Zoals verwacht van een Mendix developer is hij gewend met monsters te maken te hebben en om met Mendix te kunnen werken is het te verwachten dat deze persoon een sociopaat is. Toen hij op het plein van school merkte hij dat hij al omsingelt was en moet zijn best doen om te overleven."),
            new Character("Mechatronica", "Parody", "Mechatronica", $"Primary: Gun {Environment.NewLine}Ability: Dash (korte burst movement){Environment.NewLine}Ultimate: Schild dat kan schieten (robotje){Environment.NewLine}{Environment.NewLine}Ambitie: Wil de transformers een realiteit maken na dat hij afgestudeerd is.{Environment.NewLine}Likes: Steampunk, transformers, lego{Environment.NewLine}Dislikes: Luiheid, kaas{Environment.NewLine}{Environment.NewLine}Backstory: Optimus was op zijn vrije dag druk bezig met werken in de garage om geld te verdienen voor zijn studie. De weken die volgende leken normaal genoeg tot opeens de mensen die blootgesteld waren aan het gas begonnen te veranderen in zombies. Optimus was diep verontrust door wat er gebeurde en besloot te rennen naar een grote open gebied op het plein op zoek naar anderen om samen te werken. Hier kwam hij anderen tegen en samen hebben zij een verdediging opgezet door hulp van de turret van Optimus."),
            new Character("ElectroTechniek", "Nikola", "Electro Techniek", $"Primary: Tesla gun (korte stun en damage){Environment.NewLine}Ability: Tesla coil (klein beetje damage in radius) placeable{Environment.NewLine}Ultimate: EMP (stun) hele veld{Environment.NewLine}{Environment.NewLine}Ambitie: Groene stroom gratis maken voor iedereen op de wereld.{Environment.NewLine}Likes: Chocola, wetenschap, dieren{Environment.NewLine}Dislikes: Thomas uit klas 3A, verspilling{Environment.NewLine}{Environment.NewLine}Backstory: Nikola was op stage bij een bedrijf dat onderzoek doet naar nieuwe en efficiënte manieren om groene stroom te wekken. Op de dag dat hij zijn voortgang moest presenteren op school was hij verrast te vinden dat wat er op school rond liep geen mensen waren. Om proberen te ontsnappen rende Nikola richting het plein zodat hij goed overzicht had op wat er rond liep. Hier kwam hij meer mensen tegen die probeerden de robots af te houden. Toen de overlevenden moeite leken te krijgen kwam Nikola net op tijd aan met een EMP om de robots tijdelijk uit te schakelen wat de anderen tijd gaf om er zo veel mogelijk te slapen en op adem te komen. Nu moeten zij samen overleven tegen de horde die op hen af komt."),
            new Character("TechnischeInformatica", "Cipher", "Technische Informatica", $"Primary: Pistol schiet bullet met damage over time{Environment.NewLine}Ability: Robots elkaar laten aanvallen (gooien van een AOI bom){Environment.NewLine}Ultimate: Shield voor team (shield en heal){Environment.NewLine}{Environment.NewLine}Ambitie: Automatisering van zo veel mogelijk banen om efficiëntie te verhogen{Environment.NewLine}Likes: Bier, pretzels, braadworst{Environment.NewLine}Dislikes: Luiheid, humor{Environment.NewLine}{Environment.NewLine}Backstory: Als kind verhuisde Klaus samen met zijn ouders naar Nederland. Klaus is in Nederland opgegroeid maar heeft de typische duitse uitkijk op zaken. Klaus was al sinds hij een kind was geobsedeerd met efficiëntie. Hierom wil Klaus studeren in robotica en zo veel mogelijk werk automatiseren. Hij vermoed dat als er zo veel mogelijk geautomatiseerd is alles een stuk sneller gaat en mensen zich kunnen concentreren op belangrijkere zaken. Het was een normale dag toen Klaus naar school kwam. Tijdens zijn pauze ging opeens het alarm af en probeerde hij kalm het gebouw te verlaten voordat hij erachter kwam dat er op hol geslagen robots van elke richting kwamen. De meeste mensen leken al ontsnapt te zijn maar Klaus had geen gelukkige dag. Het enige positieve dat voor Klaus gebeurde was dat terwijl hij aan het vluchten was hij anderen tegen kwam, nu vechten zij samen de horde van robots om te overleven."),
            new Character("Werktuigbouwkunde", "Bullseye", "Werktuigbouwkunde", $"Primary: Nailgun (high damage, piercing en low fire rate){Environment.NewLine}Ability: Landmijn (met prime time){Environment.NewLine}Ultimate: Turret{Environment.NewLine}{Environment.NewLine}Ambitie: Innoveren van machines en de leefomstandigheden van mensen in relatie tot machine verbeteren.{Environment.NewLine}Likes: Voertuigen, apparaten, goede doelen{Environment.NewLine}Dislikes: Arrogantie, zelfzucht{Environment.NewLine}{Environment.NewLine}Backstory: Sinds kinds af aan was Bill al aan het sleutelen met machines. Toen Bill een tiener werd kreeg hij interesse in de theorie achter hoe de verschillende machines werkten intern en waarom dit zo was. Toen het tijd werd voor Bill om een opleiding te kiezen wist hij precies wat hij wilde doen. Hij kon zo zijn kennis van machines uitbreiden en koppelen met zijn ambitie om het menselijk leven makkelijker te maken. Hoewel het een normale dag op school was voor Bill, veranderde dat snel toen hij net naar huis wilde gaan. Hij liep rustig over het plein toen hij merkte dat iets niet klopte. Toen hij zijn koptelefoon af deed hoorde hij dat er een alarm af ging over de hele school. Toen hij zijn ogen concentreerde op de figuren die hij op een afstandje zag realiseerde hij zich dat dit helemaal geen mensen waren. Nu hij geen kant op kan moet hij zijn best doen om dit te overleven en ontsnappen of gered te worden.")
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

    internal void ScrollLore(double pos)
    {
        loreScroll.verticalNormalizedPosition = (float) pos;
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
