using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{   

    //Selector
    public GrillePipes.CaseType t;
    public GameObject pipe;

    //pathFinding
    public bool walkable;
    public bool objectif;    
    public Vector2Int position;

    public Case[] voisines; //Gauche Haut Droite Bas

    public void InitCase(bool objectif,bool walkable)
    {
        this.walkable = walkable;
        this.objectif = objectif;
    }

    public void AddPipe(GameObject pipe)
    {

    }

    public void OnMouseButtonUp()
    {
        if (t!=GrillePipes.CaseType.Case)
        {
            return;
        }
        if (PipeManager.current.dragging)
        {
            if (pipe!=null) {
                
            }
            pipe = Instantiate<GameObject>(PipeManager.current.draggingPipe,transform) as GameObject;
        }
    }
}
