using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    //Selector
    public GrillePipes.CaseType t;
    public bool occuped;

    public PipeSelector p;
    //pathFinding
    public bool walkable;
    public bool objectif;
    public Vector2Int position;

    public Case[] voisines { get; set; } //Gauche Haut Droite Bas

    public void Start()
    {

        occuped = false;
        voisines = new Case[4];
    }
    public void InitCase(bool objectif, bool walkable)
    {
        voisines = new Case[4];
        this.walkable = walkable;
        this.objectif = objectif;
    }

    public void AddPipe(GameObject pipeToAdd)
    {
       
        if (t != GrillePipes.CaseType.Case)
        {
            return;
        }
        DeletePipe();
        occuped = true;
        p = Instantiate<GameObject>(pipeToAdd, transform.position, pipeToAdd.transform.rotation, transform).GetComponent<PipeSelector>();
        p.gameObject.transform.localScale = new Vector3(1, 1, 1);
        PipeManager.current.TakePipe(p.pipeType);
       
    }

    public void OnMouseDown()
    {
        Debug.Log("click");
        if (PipeManager.current.dragging)
        {
            AddPipe(PipeManager.current.draggingPipe);
        }
        else
        {
            DeletePipe();
        }
    }

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            DeletePipe();
        }
        //Debug.Log(p.pipeType);
    }
    public void DeletePipe()
    {
        
        if (occuped)
        {
            p = null;
            occuped = false;
            Transform pipe = transform.GetChild(0);
            PipeManager.current.AddPipe(pipe.GetComponent<PipeSelector>().pipeType);
            Destroy(pipe.gameObject);
        }

    }
}
