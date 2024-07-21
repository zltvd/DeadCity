using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using System.Runtime.Serialization.Json;

[System.Serializable]
public class GameData
{
    public float patronsCount;
    public Vector3 playerPosition;
    public SerializableDictionary<string, bool> medkitCollected;
    public SerializableDictionary<string, Vector3> activeZombiesPosition;
    public SerializableDictionary<string, float> activeZombiesHP;
    public SerializableDictionary<string, bool> diedZombies;
    public string saveTime;
    public string saveDate;
    public int ggHP;
    public int currentCoins;
    public bool isGunCanBeActivate;
    public Vector3 camOfPlayerRotation;
    public bool isFirstWasShowed;


    public Vector3 minimapPosition;
    public Vector3 minimapRotation;

    public Vector3 LidiaPosition;
    public Vector3 LidiaRotation;

    public Vector3 RobertPosition;
    public Vector3 RobertRotation;

    public Vector3 KrisPosition;
    public Vector3 KrisRotation;

    public Vector3 JessPosition;
    public Vector3 JessRotation;

    public Vector3 StevePosition;
    public Vector3 SteveRotation;

    public bool isZombieFor2ndQuestAreActive;

    //здесь будут храниться данные из скрипта BaseForQuests, которые используются во многих других скриптах//
    public bool isSecondFinish;
    public int numOfDialogueWithKris;
    public bool isWave;
    public bool isMove;

    public bool isSimpleZombieDead;
    public bool isKrisMoving;

    public bool isFirstRob;
    public bool isSecondRob;
    public bool isAgainRob;
    public bool isShopUnlock;

    public bool isAgainKris;
    public bool isAgainShelter;
    public bool isSecondFloorUnlock;
    public bool isOutUnlock;

    public int isGunAndPatrons;
    public bool isStop;
    public bool isEscActive;
    public bool isGameOver;
    public float killedZombie;

    public float currentLvlOfPatrons;
    public float currentLvlOfForce;

    public string textOfQuest;
    public string textOfGoal;

    public bool isMapAndQuestAreActive;

    public string[] itemNamesGGInv;
    public int[] itemAmountsGGInv;

    public string[] itemNamesBoxInv;
    public int[] itemAmountsBoxInv;

    public bool isInvWasntEmpty;
    public bool isInvBoxWasntEmpty;

    public bool isCanMap;
    public bool isCanShoot;
    public bool wasGunCollected;

    public bool isGigantActive;

    public int maxPatronsGG;
    public int damageAmount;

    public GameData()
    {
        this.patronsCount = 0;
        playerPosition = Vector3.zero;
        medkitCollected = new SerializableDictionary<string, bool>();
        diedZombies = new SerializableDictionary<string, bool>();
        saveTime = "";
        saveDate = "";
        this.ggHP = 80;
        this.currentCoins = 0;
        this.isGunCanBeActivate = false;
        this.isFirstWasShowed = false;
        this.killedZombie = 7;
        this.currentLvlOfForce = 1;
        this.currentLvlOfPatrons = 1;
        this.isInvWasntEmpty = false;
        this.isInvBoxWasntEmpty = false;
        this.isCanMap = false;
        this.isCanShoot = false;
        this.isFirstRob = true;
        this.isAgainRob = false;
        this.isShopUnlock = false;
        this.wasGunCollected = false;
        this.isGigantActive = false;
        this.maxPatronsGG = 10;
        this.damageAmount = 15;
    }
}
