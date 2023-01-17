using System;
using System.Collections;
using System.Linq;
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

    // positioning on tilemap
    public Tilemap tileMap;
    List<GameObject> fieldSeonbae = new();
    List<GameObject> deckSeonbae = new();

    // seonbae info
    List<SbClass> seonbaeData = new List<SbClass>();

    // synergy
    SynergyProcessor synergyProcessor;
    int[] fieldSeonbaeArray;

    // Start is called before the first frame update
    void Start()
    {
        isWaveStart = false;
        gameStage = 1; // -> load from game data file

        // load seonbae data
        SeonbaeDataInit();

        // load synergy data
        synergyProcessor = new SynergyProcessor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SeonbaeDataInit()
    {
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
        List<Dictionary<string, float>> seonbaePosition = CSVReader.ReadByFloat("seonbaePosition");
        for (int i = 0; i < seonbaePosition.Count; i++)
        {
            GameObject seonbaeObj = MonoBehaviour.Instantiate(seonbaePrefab);

            Vector3Int pos = new Vector3Int((int)seonbaePosition[i]["positionX"], (int)seonbaePosition[i]["positionY"], 0);
            seonbaeObj.transform.position = tileMap.CellToLocal(pos);

            SbClass sbClass = seonbaeData[(int)seonbaePosition[i]["seonbaeId"]];
            sbClass.SetStar((int)seonbaePosition[i]["star"]);
            //print(sbClass.GetName());

            seonbaeObj.GetComponent<SbScript>().GetInfo(i, sbClass);

            if ((int)seonbaePosition[i]["state"] == 1) // in field
            {
                fieldSeonbae.Add(seonbaeObj);
            }
            else
            {
                deckSeonbae.Add(seonbaeObj);
            }

            seonbaeObj.SetActive(true);
        }
    }

    public void StartGame()
    {
        // game start init
        isWaveStart = true;

        // call seonbae function
        for (int i=0; i<fieldSeonbae.Count; i++)
        {
            fieldSeonbae[i].GetComponent<BoxCollider2D>().enabled = false;
            fieldSeonbae[i].GetComponentInChildren<PolygonCollider2D>().enabled = true;
        }

        // professor setting
        GameObject professorObj = MonoBehaviour.Instantiate(professorPrefab);
        professorObj.SetActive(true);
    }

    public void OnMove(int realSeonbaeId, int positionY, int newY) // called when seonbae moved
    {
        // get field seonbae list
        fieldSeonbaeArray = Enumerable.Repeat<int>(0, SEONBAE_NUM).ToArray<int>();
        if (positionY < -12 && newY >= -12)
        {
            // field
            
        }
        else
        {
            // deck
        }

        // synergy processor -> calculate synergy
        for (int i=0; i<SYNERGY_NUM; i++)
        {
            synergyProcessor.CallSynergy(i, fieldSeonbaeArray);
        }
    }
}
