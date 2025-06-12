using System;
using UnityEngine;

[Serializable]
public class Stats
{
    public int STR;
    public int DEX;
    public int INT;
    public int CON;
    public int WIS;
    public int CHA;

    public Stats Clone()
    {
        return new Stats
        {
            STR = this.STR,
            DEX = this.DEX,
            CON = this.CON,
            INT = this.INT,
            WIS = this.WIS,
            CHA = this.CHA
        };
    }
}
