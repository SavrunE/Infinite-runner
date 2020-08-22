using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Parameters
{
    public string Name;

    public float BaseHP = 100f;
    public float CurrentHP;
    public float BaseSpeed = 5f;
    public float CorrentSpeed;
    public float BaseAttackSpeed = 50f;
    public float CorrentAttackSpeed;
    public float BaseAttack = 25f;
    public float CurrentAttack;
    public float BaseDeffence = 0f;
    public float CorrentDeffence;


    public enum Type
    {
        Grass,
        Fire,
        Wather,
        Electric
    }

    public enum Rarity
    {
        Common,
        Uncommon,
        Rara,
        SuperRare
    }

    public Type EnemyType;
    public Rarity EnemyRarity;

}

