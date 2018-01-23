using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public GrillePipes.CaseType t;
    public bool walkable;
    public bool objectif;
    public bool occuped;
    public Vector2Int position;

    public Case[] voisines;

    public void Start()
    {
        occuped= false;
    }

    public void InitCase(bool objectif,bool walkable, Vector2Int position)
    {
        this.walkable = walkable;
        this.position = position;
    }
}
