using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public int charLevel = 0;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int strenght;
    public int defence;
    public int weaponPower;
    public int armourPower;
    public string equippedWeapon;
    public string equippedArmour;
    public Sprite charImage;

    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;
        for(int i=2; i<expToNextLevel.Length; i++)
        {

        }
    }

    void Update()
    {
        
    }
}
