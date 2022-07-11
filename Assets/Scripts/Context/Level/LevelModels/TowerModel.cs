using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerModel
{
    public TowerConfig Config { get; private set; }
    public int Damage { get; set; }
    public float ShootRadius { get; set; }
    public float ShootFrequency { get; set; }
    public int BulletsNumber { get; set; }
    public int Cost { get; set; }
    public TowerModel(TowerConfig config)
    {
        Config = config;
        Damage = config.Damage;
        ShootRadius = config.ShootRadius;
        ShootFrequency = config.ShootFrequency;
        BulletsNumber = config.BulletsNumber;
        Cost = config.Cost;
    }

    public void Upgrade(UpgradeConfig upgradeConfig)
    {
        Damage += upgradeConfig.Damage;
        ShootRadius += upgradeConfig.ShootRadius;
        ShootFrequency += upgradeConfig.ShootFrequency;
        BulletsNumber += upgradeConfig.BulletsNumber;
    }
}
