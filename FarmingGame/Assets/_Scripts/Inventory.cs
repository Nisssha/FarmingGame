using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EInventoryObject
{
    EHoe,
    ERandomSeed,
    EPlant,
    ENone
}

public enum EPlants
{
    ECarrot,
    EBean,
    EPaprica,
    EPotato,
    ENone
}

public struct InventoryObject
{
    EInventoryObject ObjectType;
    EPlants PlantType;
    int Amount;

    public InventoryObject(EInventoryObject objectType, EPlants plantType, int amount)
    {
        ObjectType = objectType;
        PlantType = plantType;
        Amount = amount;
    }

    public EInventoryObject GetObjectType() { return ObjectType; }
    public EPlants GetPlantType() { return PlantType; }
    public int GetAmount() { return Amount; }
}

public class Inventory : MonoBehaviour {

    List<InventoryObject> HeldObjects = new List<InventoryObject>();
    int IndexActive = 0;

    public List<Button> InventorySlots = new List<Button>();

    // Use this for initialization
    void Start()
    {
        HeldObjects.Add(new InventoryObject(EInventoryObject.EHoe, EPlants.ENone, 1));
        HeldObjects.Add(new InventoryObject(EInventoryObject.ERandomSeed, EPlants.ENone, 1));

        for(int i = HeldObjects.Count; i < InventorySlots.Count; i++)
        {
            HeldObjects.Add(new InventoryObject(EInventoryObject.ENone, EPlants.ENone, 0));
        }

        for(int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].GetComponentInChildren<Text>().text = GetText(HeldObjects[i]);
        }
    }
	
    public void OnSlotClicked(int index)
    {
        IndexActive = index;
    }

    public InventoryObject GetSelectedObject()
    {
        return HeldObjects[IndexActive];
    }

    private string GetText(InventoryObject objectCat)
    {
        switch (objectCat.GetObjectType())
        {
            case EInventoryObject.EHoe:
                return "Hoe";
            case EInventoryObject.ERandomSeed:
                return "Seed";
            case EInventoryObject.EPlant:
                return "Plant";
            case EInventoryObject.ENone:
                return "";
        }

        return "error";
    }
}
