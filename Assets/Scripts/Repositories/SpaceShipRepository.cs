using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipEnums
{
    Green1, Green2, Green3,
    Red1, Red2, Red3,
    Blue1, Blue2, Blue3,
}

[System.Serializable]
public struct ShipStruct
{
    public ShipEnums key;
    public GameObject ship;
}


public class SpaceShipRepository : MonoBehaviour
{

    public ShipStruct[] ships;

    private const string currentShipRepository = "currentShipRepository";
    private const string ShipsRepository = "shipsRepository";

    public GameObject GetCurrentShip()
    {
        //int index = PlayerPrefs.GetInt(currentShipRepository);
        int index = 1;
        return ships[index].ship;
    }

    public void SetCurrentShip()
    {

    }

    public void ActiveNewShip()
    {

    }

    private void Start()
    {

    }



}
