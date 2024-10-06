using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceManager : MonoBehaviour
{
    // ? Private variables
    private int _currentWood = 0;
    private int _currentStone = 0;
    private int _currentMoney = 0;
    private int _currentWoodHouse = 0;
    private int _currentStoneHouse = 0;
    private int _currentMixedHouse = 0;

    // ? Public variables
    public int initialMoney = 100;
    public int moneyPerKeydown = 20;
    public int woodCost = 10;
    public int stoneCost = 15;
    public int maxResources = 20;
    public int woodHouseCost = 5;
    public int stoneHouseCost = 5;
    public int mixedHouseWoodCost = 5;
    public int mixedHouseStoneCost = 5;

    void Start()
    {
        Debug.Log("Welcome! \n Press 'W' to buy wood, 'S' to buy stone and 'E' to earn money. \n Press 'H', 'P' or 'M' to build wood, stone or mixed houses.");
        Debug.Log($"You've earned {initialMoney} money!");
        _currentMoney = initialMoney;
    }

    void Update()
    {
        CheckInputs();
    }

    private void CheckInputs(){
        if(Input.GetKeyDown(KeyCode.W)){
            GetWood();
        }
        if(Input.GetKeyDown(KeyCode.S)){
            GetStone();
        }
        if(Input.GetKeyDown(KeyCode.E)){
            GetMoney();
        }
        if(Input.GetKeyDown(KeyCode.H)){
            BuildWoodHouse();
        }
        if(Input.GetKeyDown(KeyCode.P)){
            BuildStoneHouse();
        }
        if(Input.GetKeyDown(KeyCode.M)){
            BuildMixedHouse();
        }
    }

    private void GetWood(){
        if(_currentMoney < woodCost){
            Debug.LogError("You don't have enough money to buy wood. Press 'E' to earn money.");
            return;
        }
        
        if(_currentWood >= maxResources){
            Debug.LogError($"The wood limit is {maxResources}.");
            return;
        }

        _currentWood++;
        _currentMoney -= woodCost;
    }

    private void GetStone(){
        if(_currentMoney < stoneCost){
            Debug.LogError("You don't have enough money to buy stone. Press 'E' to earn money.");
            return;
        }
        
        if(_currentStone >= maxResources){
            Debug.LogError($"The stone limit is {maxResources}.");
            return;
        }

        _currentStone++;
        _currentMoney -= stoneCost;
    }

    private void GetMoney(){
        _currentMoney += moneyPerKeydown;
        Debug.Log($"Current money: {_currentMoney}");
    }

    private void BuildWoodHouse(){
        if(_currentWood < woodHouseCost){
            Debug.LogError("You don't have enough wood. Press W to buy wood.");
            return;
        }
        _currentWoodHouse++;
        _currentWood -= woodHouseCost;
        Debug.Log("You have built a wood house!");
    }

    private void BuildStoneHouse(){
        if(_currentStone < stoneHouseCost){
            Debug.LogError("You don't have enough stone. Press S to buy stone.");
            return;
        }
        _currentStoneHouse++;
        _currentStone -= stoneHouseCost;
        Debug.Log("You have built a stone house!");
    }

    private void BuildMixedHouse(){
        if(_currentWood < mixedHouseWoodCost && _currentStone < mixedHouseStoneCost){
            Debug.LogError("You don't have enough resources. Press W or S to buy wood or stone.");
            return;
        }
        _currentMixedHouse++;
        _currentWood -= mixedHouseWoodCost;
        _currentStone -= mixedHouseStoneCost;
        Debug.Log("You have built a mixed house!");
    }
}
