using System.Collections.Generic;
using UnityEngine;


public class PlantSelectionUI : MonoBehaviour
{
    public GameObject PlantSelectionPanel;
    public Transform content;
    public PlantCard plantCardPrefab;
    public PlantSpot currentSpot;

    public List<PlantCard> activePlantCards = new List<PlantCard>();

    public void OpenUI(PlantSpot spot)
    {
        currentSpot = spot;

        PlantSelectionPanel.SetActive(true);


        G.player.SetMovementEnabled(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseUI()
    {
        PlantSelectionPanel.SetActive(false);

        G.player.SetMovementEnabled(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CreatePlantCard(string id)
    {
        PlantData plant = AllPlants.GetPlantData(id);
        PlantCard plantCard = Instantiate(plantCardPrefab, content);
        plantCard.Setup(plant);

        activePlantCards.Add(plantCard);
    }

    public void RefreshPlantsCost()
    {
        foreach (var plantCard in activePlantCards)
        {
            plantCard.RefreshCost();
        }
    }

    public void Reset()
    {
        while (activePlantCards.Count > 0)
        {
            activePlantCards[0].Delete();
        }

        CreatePlantCard("unknown_plant");

        RefreshPlantsCost();
    }
}
