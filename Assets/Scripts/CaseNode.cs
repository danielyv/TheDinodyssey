using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseNode
{
    public bool walkable;
    public bool objectif;
    public Vector2Int position;

    public CaseNode[] voisines;

    public CaseNode(bool walkable, Vector2Int position)
    {
        this.walkable = walkable;
        this.position = position;
    }
}
