using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SynergyProcessor
{
    // constant declaration
    const int SYNERGY_NUM = 10;
    const int SEONBAE_NUM = 29;

    // save synergy data
    private readonly List<List<int>> synergyConditions = new();
    private readonly Dictionary<int, string> synergyNames = new();
    private readonly List<Dictionary<string, float>> synergyEffect = new();

    // initializer
    public SynergyProcessor()
    {
        List<Dictionary<string, string>> synergy_reader = CSVReader.ReadByString("synergy");
        synergyEffect = CSVReader.ReadByFloat("synergyEffect");

        // load synergy csv file
        for (int i = 0; i < SYNERGY_NUM; i++)
        {
            synergyNames[i] = synergy_reader[i]["synergy"]; // save synergy names
            string sSynergy = synergy_reader[i]["key"];
            List<int> nArraySynergy = sSynergy.Split(',').Select(Int32.Parse).ToList();

            synergyConditions.Add(nArraySynergy);
        }
    }

    public List<int> GetSynergyCondition(int synergyId)
    {
        return synergyConditions[synergyId];
    }

    public string GetSynergyName(int synergyId)
    {
        return synergyNames[synergyId];
    }

    public void CallSynergy(int synergyId, int[] fieldSeonbae)
    {
        List<int> condition = GetSynergyCondition(synergyId);
        Dictionary<string, float> effect = synergyEffect[synergyId]; 

        // count satisfied condition
        int satisfyCount = 0;
        for (int i=0; i<SEONBAE_NUM; i++)
        {
            if (condition[i] * fieldSeonbae[i] > 0)
            {
                satisfyCount++;
            }
        }
        
        if (satisfyCount >= 2 && satisfyCount <= 7)
        {
            float effectValue = effect[satisfyCount.ToString()];

            switch (synergyId)
            {
                case 0:
                    // attack power +
                    break;
                case 1:
                    // attack time -
                    break;
                case 2:
                    // skill cool time -
                    break;
                case 3:
                    // no skill
                    break;
                case 4:
                    // no skill
                    break;
                case 5:
                    // no skill
                    break;
                case 6:
                    // pf hp -
                    break;
                case 7:
                    // more gold +
                    break;
                case 8:
                    // skill power +
                    break;
                case 9:
                    // pf velocity -
                    break;
            }
        }
    }
}
