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
    private int currentPlayerMaxMana;

    public int startingCardsAmount = 5;
    public int cardsToDrawPerTurn = 1;

    public enum TurnOrder { playerActive, playerCardAttacks, enemyActive, enemyCardAttacks }
    public TurnOrder currentPhase;

    void Start()
    {
        //playerMana = startingMana;
        //UIController.instance.SetPlayerManaText(playerMana);
        currentPlayerMaxMana = startingMana;
        FillPlayerMana();

        DeckController.instance.DrawMultipleCards(startingCardsAmount);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AdvanceTurn();
        }
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

    public void FillPlayerMana()
    {
        //playerMana = startingMana;
        playerMana = currentPlayerMaxMana;
        UIController.instance.SetPlayerManaText(playerMana);
    }

    public void AdvanceTurn()
    {
        currentPhase++;

        if((int)currentPhase >= System.Enum.GetValues(typeof(TurnOrder)).Length)
        {
            currentPhase = 0;
        }

        switch(currentPhase)
        {
            case TurnOrder.playerActive:

                UIController.instance.endTurnButton.SetActive(true);
                UIController.instance.drawCardButton.SetActive(true);

                if (currentPlayerMaxMana < maxMana)
                {
                    currentPlayerMaxMana++;
                }

                FillPlayerMana();

                DeckController.instance.DrawMultipleCards(cardsToDrawPerTurn);

                break;

            case TurnOrder.playerCardAttacks:

                //Debug.Log("Skipping player card attacks");
                //AdvanceTurn();

                CardPointsController.instance.PlayerAttack();

                break;

            case TurnOrder.enemyActive:

                Debug.Log("Skipping enemy actions");
                AdvanceTurn();

                break;

            case TurnOrder.enemyCardAttacks:

                Debug.Log("Skipping enemy card attacks");
                AdvanceTurn();

                break;
        }
    }

    public void EndPlayerTurn()
    {
        UIController.instance.endTurnButton.SetActive(false);
        UIController.instance.drawCardButton.SetActive(false);

        AdvanceTurn();
    }
}
