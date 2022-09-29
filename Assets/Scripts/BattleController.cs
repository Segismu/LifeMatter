using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    private void Awake()
    {
        instance = this;
    }

    public int startingMana = 1, maxMana = 11;
    public int playerMana;

    public int startingCardsAmount = 5;

    void Start()
    {
        playerMana = startingMana;
        UIController.instance.SetPlayerManaText(playerMana);

        DeckController.instance.DrawMultipleCards(startingCardsAmount);
    }

    void Update()
    {
        
    }

    public void SpendPlayerMana(int amountToSpend)
    {
        playerMana = playerMana - amountToSpend;

        if (playerMana <= 0)
        {
            playerMana = 0;
        }

        UIController.instance.SetPlayerManaText(playerMana);
    }
}
