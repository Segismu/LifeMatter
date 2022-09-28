using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public List<Card> heldCards = new List<Card>();

    public Transform minPos, maxPos;
    public List<Vector3> cardPositions = new List<Vector3>();

    void Start()
    {
        SetCardPosInHand();
    }

    void Update()
    {
        
    }

    public void SetCardPosInHand()
    {
        cardPositions.Clear();

        Vector3 distanceBetweenPoints = Vector3.zero;
        if (heldCards.Count > 1)
        {
            distanceBetweenPoints = (maxPos.position - minPos.position) / (heldCards.Count - 1);
        }

        for (int i = 0; i < heldCards.Count; i++)
        {
            cardPositions.Add(minPos.position + (distanceBetweenPoints * i));

            //heldCards[i].transform.position = cardPositions[i];
            //heldCards[i].transform.rotation = minPos.rotation;

            // This sets where the card should move to
            heldCards[i].MoveToPoint(cardPositions[i], minPos.rotation);

            heldCards[i].inHand = true;
            heldCards[i].handPos = i;
        }
    }

    public void RemoveCardFromHand(Card cardToRemove)
    {
        if (heldCards[cardToRemove.handPos] == cardToRemove)
        {
            heldCards.RemoveAt(cardToRemove.handPos);
        }
        else
        {
            Debug.LogError("Card at pos " + cardToRemove.handPos + " is not the card being removed from hand.");
        }

        SetCardPosInHand();
    }

}
