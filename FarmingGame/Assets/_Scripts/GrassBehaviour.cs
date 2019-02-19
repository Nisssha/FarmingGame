using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBehaviour : MonoBehaviour {

    public Sprite TiledVisuals;
    public Sprite UnTiledVisuals;
    public bool CanBePlantedOn = true;

    private bool IsHoed = false;
    private bool HasPlant = false;
    private PlantGrow Plant = null;

    public void HoeGround()
    {
        GetComponent<SpriteRenderer>().sprite = TiledVisuals;
        IsHoed = true;
    }

    public void PlantOnTile(PlantGrow plant)
    {
        Plant = plant;
        HasPlant = true;
    }

    public PlantGrow GetPlantFromTile()
    {
        return Plant;
    }

    public void CleanTile()
    {
        HasPlant = false;
        Plant = null;
    }

    //todo random chance to un-tile if no plant

    public bool GetCanBeHoed() { return CanBePlantedOn && !HasPlant; }
    public bool GetCanBePlantedOn() { return CanBePlantedOn && IsHoed && !HasPlant; }
    public bool GetHasPlant() { return HasPlant; }
}
