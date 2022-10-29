using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{
    // constant declaration
    const int SYNERGY_NUM = 10;
    const int SEONBAE_NUM = 29;

    // prefab
    public GameObject seonBae, professor;

    // game variables
    public int nGameLevel;
    bool isStartGame;

    SynergyProcessor synergyProcessor;

    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, string>> seonbae_reader = CSVReader.ReadByString("seonbae");

        isStartGame = false;
        nGameLevel = 1; // -> load from game data file

        // make seonbae prefab from game data file (deck, field)

        // load seonbae data

        // load synergy data
        synergyProcessor = new SynergyProcessor();

        //test
        print(synergyProcessor.GetSynergyCondition(0)[3]); // 1
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStartGame)
        {
            // ready state
        }
        else
        {
            // game state
        }
    }

    public void StartGame(int gameLevel)
    {
        // game start init
        isStartGame = true;

        // call seonbae function
    }

    public void OnMove() // called when seonbae moved
    {
        // get field seonbae list

        // synergy processor -> calculate synergy
    }
}
