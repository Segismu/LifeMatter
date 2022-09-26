using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardScriptableObject cardSO;

    public int currentHP, attackPower, manaCost;

    public TMP_Text hpText, attackText, costText, nameText, actionText, loreText;

    public Image characterArt, bgArt;

    void Start()
    {
        SetupCard();
    }

    private void SetupCard()
    {
        currentHP = cardSO.currentHP;
        attackPower = cardSO.attackPower;
        manaCost = cardSO.manaCost;

        hpText.text = currentHP.ToString();
        attackText.text = attackPower.ToString();
        costText.text = manaCost.ToString();

        nameText.text = cardSO.cardName;
        actionText.text = cardSO.actionDescription;
        loreText.text = cardSO.cardLore;

        characterArt.sprite = cardSO.characterSprite;
        bgArt.sprite = cardSO.bgSprite;
        
    }

    void Update()
    {
        
    }
}
