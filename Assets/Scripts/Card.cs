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

    private Vector3 targetPoint;
    public float moveSpeed = 5f, rotSpeed = 540f;
    public Quaternion targetRot;

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
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
    }

    public void MoveToPoint(Vector3 pointToMoveTo, Quaternion rotToMatch)
    {
        targetPoint = pointToMoveTo;
        targetRot = rotToMatch;
    }
}
