using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    // Use this for initialization
    private GameMaster GameMasterScript;
    private Inventory PlayerInventory;

    public float speed = 6.0f;
    public PlantGrow SelectedPlant;
    public Camera CharacterCamera;

    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        GameMasterScript = FindObjectOfType<GameMaster>();
        PlayerInventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        // Move the controller
        this.transform.Translate(moveDirection * Time.deltaTime);

        if (Input.GetButtonDown("UseAction"))
        {
            switch (PlayerInventory.GetSelectedObject().GetObjectType())
            {
                case EInventoryObject.EHoe:
                    HoeGround();
                    break;
                case EInventoryObject.ERandomSeed:
                    Plant();
                    break;
                case EInventoryObject.ENone:
                    CollectPlant();
                    break;
            }
        }
    }

    void Plant()
    {
        GrassBehaviour tile = GameMasterScript.GetGrassTile(this.transform.position);
        if (tile.GetCanBePlantedOn())
        {
            PlantGrow plant = Instantiate(GameMasterScript.GetPlant(EPlantRarity.ECommon), tile.transform.position, Quaternion.identity);
            tile.PlantOnTile(plant);
        }
    }

    void HoeGround()
    {
        GrassBehaviour tile = GameMasterScript.GetGrassTile(this.transform.position);
        if (tile.GetCanBeHoed())
        {
            tile.HoeGround();
        }
    }

    void CollectPlant()
    {
        GrassBehaviour tile = GameMasterScript.GetGrassTile(this.transform.position);
        if (tile.GetHasPlant())
        {
            GameMasterScript.RemovePlant(tile.GetPlantFromTile());
            tile.CleanTile();
        }
    }

    //public void UseHoe(bool bShouldUseHoe)
    //{
    //    HoeSelected = bShouldUseHoe;
    //}
}
