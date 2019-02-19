using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMaster : MonoBehaviour
{
    public List<GameObject> PossiblePlantsCommon = new List<GameObject>();
    public List<GameObject> PossiblePlantsRare = new List<GameObject>();
    public List<GameObject> PossiblePlantsVeryRare = new List<GameObject>();
    public List<GameObject> PossiblePlantsEpic = new List<GameObject>();

    private int DayIndex = 0;
    List<PlantGrow> CurrentPlants = new List<PlantGrow>();
    private GrassBehaviour[] MapTiles;

	// Use this for initialization
	void Start ()
    {
        MapTiles = FindObjectsOfType<GrassBehaviour>();
	}
	

    public void NewDayRequest()
    {
        DayIndex++;

        foreach(PlantGrow plant in CurrentPlants)
        {
            plant.DayFinished();
        }
    }

    public PlantGrow GetPlant(EPlantRarity rarityLevel)
    {
        if (rarityLevel == EPlantRarity.ECommon)
        {
            return PossiblePlantsCommon[Random.Range(0, PossiblePlantsCommon.Count)].GetComponent<PlantGrow>();
        }
        else if (rarityLevel == EPlantRarity.ERare)
        {
            return PossiblePlantsRare[Random.Range(0, PossiblePlantsRare.Count)].GetComponent<PlantGrow>();
        }
        else if (rarityLevel == EPlantRarity.EVeryRare)
        {
            return PossiblePlantsVeryRare[Random.Range(0, PossiblePlantsVeryRare.Count)].GetComponent<PlantGrow>();
        }
        else if (rarityLevel == EPlantRarity.EEpic)
        {
            return PossiblePlantsEpic[Random.Range(0, PossiblePlantsEpic.Count)].GetComponent<PlantGrow>();
        }

        throw new System.Exception();
    }

    public void AddNewPlant(PlantGrow newPlant)
    {
        CurrentPlants.Add(newPlant);
    }

    public void RemovePlant(PlantGrow planttoRemove)
    {
        CurrentPlants.Remove(planttoRemove);
    }

    public GrassBehaviour GetGrassTile(Vector3 location)
    {
        GrassBehaviour selectedTile = null;
        float lastSmallestDist = float.MaxValue;
        foreach(GrassBehaviour tile in MapTiles)
        {
            if(Mathf.Abs(Vector3.Distance(location, tile.transform.position)) < lastSmallestDist) //smallest difference
            {
                selectedTile = tile;
                lastSmallestDist = Mathf.Abs(Vector3.Distance(location, tile.transform.position));
            }
        }

        return selectedTile;
    }

    //getters section
    public int GetDayIndex() { return DayIndex; }
}
