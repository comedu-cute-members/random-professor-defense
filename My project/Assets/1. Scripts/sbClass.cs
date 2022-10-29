using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class sbClass
{
    int id;
    string name;
    float score;
    string skillName;
    int atkPower;
    float speed;
    int sklPower;

    public sbClass()
    {
        // init
    }

    public sbClass(int id, string name, int score, string skillName, int atkPower, float speed, int sklPower)
    {
        this.id = id;
        this.name = name;
        this.score = score;
        this.skillName = skillName;
        this.atkPower = atkPower;
        this.speed = speed;
        this.sklPower = sklPower;
    }

    public int GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public float GetScore()
    {
        return score;
    }

    public string GetSkillName()
    {
        return skillName;
    }

    public int GetAtkPower()
    {
        return atkPower;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetSklPower()
    {
        return sklPower;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetScore(float score)
    {
        this.score=score;
    }

    public void SetSkillName(string skillName)
    {
        this.skillName=skillName;
    }

    public void SetAtkPower(int atkPower)
    {
        this.atkPower = atkPower;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetSklPower(int sklPower)
    {
        this.sklPower = sklPower;
    }
}
