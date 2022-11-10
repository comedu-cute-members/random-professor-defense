using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DirectorScript : MonoBehaviour
{
    // constant declaration
    const int SYNERGY_NUM = 10;
    const int SEONBAE_NUM = 29;

    // prefab
    public GameObject seonbaePrefab, professorPrefab;

    // game variables
    public int gameStage;
    public int gameWave;
    bool isWaveStart;

    public Tilemap tileMap;
    int[] fieldSeonbae;
    int[] deckSeonbae;

    public int x, y;

    List<SbClass> seonbaeData = new List<SbClass>();
    List<Dictionary<string, float>> seonbaePosition = new List<Dictionary<string, float>>();

    SynergyProcessor synergyProcessor;

    // Start is called before the first frame update
    void Start()
    {
        isWaveStart = false;
        gameStage = 1; // -> load from game data file

        // make seonbae prefab from game data file (deck, field)

        // load seonbae data
        List<Dictionary<string, string>> seonbaeReader = CSVReader.ReadByString("seonbae");
        for (int i = 0; i < SEONBAE_NUM; i++)
        {
            SbClass entry = new SbClass();
            entry.SetId(i);
            entry.SetName(seonbaeReader[i]["name"]);
            entry.SetScore(float.Parse(seonbaeReader[i]["score"]));
            entry.SetSkillName(seonbaeReader[i]["skill_name"]);
            entry.SetAtkPower(int.Parse(seonbaeReader[i]["attack"]));
            entry.SetSpeed(float.Parse(seonbaeReader[i]["speed"]));
            entry.SetSklPower(int.Parse(seonbaeReader[i]["skill"]));

            seonbaeData.Add(entry);
        }

        // load seonbae position data
        seonbaePosition = CSVReader.ReadByFloat("seonbaePosition");
        for (int i=0; i < seonbaePosition.Count; i++)
        {
            GameObject seonbaeObj = MonoBehaviour.Instantiate(seonbaePrefab);

            Vector3Int pos = new Vector3Int((int)seonbaePosition[i]["positionX"], (int)seonbaePosition[i]["positionY"], 0);
            seonbaeObj.transform.position = tileMap.CellToLocal(pos);

            SbClass sbClass = seonbaeData[(int)seonbaePosition[i]["seonbaeId"]];
            sbClass.SetStar((int)seonbaePosition[i]["star"]);
            print(sbClass.GetName());
            seonbaeObj.GetComponent<SbScript>().GetInfo(sbClass);
        }

        // load synergy data
        synergyProcessor = new SynergyProcessor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaveStart)
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
        isWaveStart = true;

        // call seonbae function
    }

    public void OnMove() // called when seonbae moved
    {
        // get field seonbae list

        // synergy processor -> calculate synergy
    }
}
