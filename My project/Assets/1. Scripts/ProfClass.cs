using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ProfClass
{
    int ProfAttack;
    int ProfHp;
    float ProfSpeed;
    string ProfName;


    public ProfClass(int ProfAttack,int ProfHp, float ProfSpeed, string ProfName)
    {
        this.ProfAttack = ProfAttack;
        this.ProfHp= ProfHp;
        this.ProfSpeed= ProfSpeed;
        this.ProfName= ProfName;
    }

    public int GetProfAttack()
    {
        return ProfAttack;
    }
    public int GetProfHp()
    {
        return ProfHp;
    }
    public float GetProfSpeed()
    {
        return ProfSpeed;
    }
    public string GetProfName()
    {
        return ProfName;
    }
    public void SetProfAttack(int ProfAttack)
    {
        this.ProfAttack = ProfAttack;
    }
    public void SetProfHp(int ProfHp)
    {
        this.ProfHp = ProfHp;
    }
    public void SetProfSpeed(float ProfSpeed)
    {
        this.ProfSpeed = ProfSpeed;
    }
    public void SetProfName(string ProfName)
    {
        this.ProfName = ProfName;
    }
}
