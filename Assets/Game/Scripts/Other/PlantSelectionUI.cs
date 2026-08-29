using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public class PlantSelectionUI : MonoBehaviour
{
    public GameObject PlantSelectionPanel;
    public Transform content;
    public PlantCard plantCardPrefab;
    public PlantSpot currentSpot;

    public List<PlantCard> activePlantCards = new List<PlantCard>();

    private bool isOpen = false;

    public void OpenUI(PlantSpot spot)
    {
        currentSpot = spot;

        PlantSelectionPanel.SetActive(true);
        isOpen = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseUI()
    {
        PlantSelectionPanel.SetActive(false);

        isOpen = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public PlantCard CreatePlantCard(string id)
    {
        PlantData plant = AllPlants.GetPlantData(id);
        PlantCard plantCard = Instantiate(plantCardPrefab, content);
        plantCard.Setup(plant);

        return plantCard;
    }

    public void RefreshPlantsCost()
    {
        foreach (var plantCard in activePlantCards)
        {
            plantCard.RefreshCost();
        }
    }
    public bool IsOpen() { return isOpen; }

    public void Reset()
    {
        foreach (var plantCard in activePlantCards)
        {
            plantCard.Delete();
        }
        activePlantCards.Add(CreatePlantCard("unknown_plant"));

        RefreshPlantsCost();
    }
}
