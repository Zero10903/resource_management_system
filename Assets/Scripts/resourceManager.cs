using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resourceManager : MonoBehaviour
{
    // ? Private variables
    private int _currentWood;
    private int _currentStone;
    private int _currentMoney;

    // ? Public variables
    public int initialMoney = 100;
    public int moneyPerKeydown = 20;
    public int woodCost = 10;
    public int stoneCost = 15;
    public int maxResources = 20;

    void Start()
    {
        Debug.Log("Welcome! \n Press 'W' to buy wood, 'S' to buy stone and 'E' to earn money.");
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
}
