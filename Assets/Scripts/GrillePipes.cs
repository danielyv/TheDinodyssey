using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillePipes : MonoBehaviour
{
    public enum CaseType :int { Start, End, Case, Block }

    public static int size;

    public GameObject PipeFin;
    public GameObject PipeDebut;
    public GameObject Case;
    public GameObject Block;

    public GameObject[,] Cases;

    Vector2Int positionDebut;
    Vector2Int positionFin;

    public void Awake()
    {
        size = 4;
        Debug.Log(Case);        
        Generation();
    }

    public void Generation()
    {
        int debut = Random.Range(0, size);
        int fin = Random.Range(0, size);

        positionDebut = new Vector2Int(0, debut);
        positionFin = new Vector2Int(size - 1, fin);

        Cases = new GameObject[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (i == 0 && j == debut)
                {
                    Cases[i, j] = Instantiate<GameObject>(PipeDebut) as GameObject;
                    Cases[i, j].name = "Debut";

                }
                else if (i == size - 1 && j == fin)
                {
                    Cases[i, j] = Instantiate<GameObject>(PipeFin) as GameObject;
                    Cases[i, j].name = "Fin";
                }
                else
                {
                    int r = Random.Range(0, 12);
                    if (r > 2 || i == 0 || i == size - 1 || j == 0 || j == size - 1 || (i == 1 && j == debut) || (i == size - 2 && j == fin))
                    {
                        Cases[i, j] = (GameObject) Instantiate<GameObject>(Case);
                        Cases[i, j].name = "Case" + i + j;
                    }
                    else
                    {
                        Cases[i, j] = Instantiate<GameObject>(Block) as GameObject;
                        Cases[i, j].name = "Block";
                    }
                }
                Cases[i, j].transform.parent = this.transform;
                //Scale
                float height = Camera.main.orthographicSize * 2.0f; //hauteur
                float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height; //largeur
                float caseWidth = width / (size * 2);
                float grilleHeight = caseWidth * size;
                Cases[i, j].transform.localScale = new Vector3(caseWidth, caseWidth, -1); // 1/8 de la largeur

                //position
                Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(1, 1)); // bas gauche de l'écran                
                v.x += (0.6f + i) * Cases[i, j].transform.localScale.x;
                //v.y += (0.6f + j + (height - grilleHeight) / 2) * c.transform.localScale.y;
                v.y += (0.6f+ j) * Cases[i, j].transform.localScale.y;
                v.z = 0;
                Cases[i, j].transform.position = v;

                Cases[i, j].GetComponent<Case>().position= new Vector2Int(i,j);
            }
        }
        //CasesGeneration();
    }

    public void CasesGeneration()
    {
        foreach (GameObject g in Cases)
        {
            Case c = g.GetComponent<Case>();

            //Init objectif et walkable
            if (c.t == CaseType.Case)
            {
                if (c.position == new Vector2Int(size-2, positionFin.y))
                {
                    c.InitCase(true, true);
                }
                else
                {
                    c.InitCase(false, true);
                }
            }
            else 
            {
                c.InitCase(false, false);
            }

            //Voisins
            Case empty = new GameObject().AddComponent<Case>();
            empty.InitCase(false, false);
            //Horizontal
            if (c.position.x==0)
            { 
                c.voisines[0] = empty;
                c.voisines[3] = Cases[c.position.x + 1, c.position.y].GetComponent<Case>();
            }
            else if (c.position.x==size-1)
            {
                c.voisines[0] = Cases[c.position.x - 1, c.position.y].GetComponent<Case>();
                c.voisines[3] = empty;
            }
            else
            {
                c.voisines[0] = Cases[c.position.x - 1, c.position.y].GetComponent<Case>();
                c.voisines[3] = Cases[c.position.x + 1, c.position.y].GetComponent<Case>();
            }

            //Vertical

            if (c.position.y==0)
            {
                c.voisines[1] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
                c.voisines[4] = empty;

            }
            else if (c.position.y == size-1)
            {
                c.voisines[1] = empty;
                c.voisines[4] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
            }
            else
            {
                c.voisines[1] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
                c.voisines[4] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
            }
        }
    }

    public LinkedList<int> PathFinding(int size, Case debut, Case fin)
    {
        LinkedList<Case> marked = new LinkedList<Case>();
        List<Case> verified = new List<Case>();
        LinkedList<LinkedList<int>> paths = new LinkedList<LinkedList<int>>();
        LinkedList<int> finalpath = new LinkedList<int>();

        bool found = false;

        marked.AddFirst(debut);

        paths.AddFirst(new LinkedList<int>());

        while (!found && marked.Count!=0)
        {
            Case current = marked.First.Value;
            for(int i=0;i<4; i++)
            {
                Case next = current.voisines[i];
                if (next.objectif)
                {
                    finalpath = paths.First.Value;
                    finalpath.AddLast(i);
                    found = true;
                }
                else if (next.walkable && !marked.Contains(next) && !verified.Contains(next))
                {
                    marked.AddLast(next);
                    LinkedList<int> path = new LinkedList<int>(paths.First.Value);
                    path.AddLast(i);
                    paths.AddLast(path);
                }
            }
            verified.Add(current);
            marked.RemoveFirst();
            paths.RemoveFirst();
        }        

        return finalpath;
    }
}
