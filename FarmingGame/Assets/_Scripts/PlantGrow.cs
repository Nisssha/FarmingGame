using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlantRarity
{
    ECommon,
    ERare,
    EVeryRare,
    EEpic
}

public class PlantGrow : MonoBehaviour
{
    private GameMaster GameMasterScript;
    public int GrowDays = 5;
    public Sprite[] Stages;
    public int[] ChangeDays;
    public EPlants PlantType;

    public EPlantRarity RarityLevel;

    int DaysGrowing = 0;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    private void Start()
    {
        GameMasterScript = FindObjectOfType<GameMaster>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Stages[1];

        GameMasterScript.AddNewPlant(this);
    }

    public void DayFinished()
    {
        DaysGrowing++;
        for (int i = 0; i < ChangeDays.Length - 1; i++)
        {
            if (ChangeDays[i] == DaysGrowing)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Stages[ChangeDays[i]];

                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Stages[ChangeDays[i]];
                return;
            }
        }
    }

    public void CollectPlant()
    {
        GameMasterScript.RemovePlant(this);
    }
}
