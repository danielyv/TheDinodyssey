using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillePipes : MonoBehaviour
{
    public enum CaseType : int { Start, End, Case, Block }

    public static int size;

    public GameObject PipeFin;
    public GameObject PipeDebut;
    public GameObject Case;
    public GameObject Block;

    public GameObject[,] Cases;

    public static Vector3 scale;

    Vector2Int positionDebut;
    Vector2Int positionFin;

    public void Awake()
    {
        size = 6;

        Generation();

    }

    public void Start()
    {
        
    }
    public void Generation()
    {
        SetScale();
        LinkedList<int> caseTab = null;
        while (caseTab == null)
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
                        Cases[i, j] = (GameObject)Instantiate<GameObject>(PipeDebut);
                        Cases[i, j].name = "Debut";

                    }
                    else if (i == size - 1 && j == fin)
                    {
                        Cases[i, j] = (GameObject)Instantiate<GameObject>(PipeFin);
                        Cases[i, j].name = "Fin";
                    }
                    else
                    {
                        int r = Random.Range(0, 12);
                        if (r > 2 || i == 0 || i == size - 1 || j == 0 || j == size - 1 || (i == 1 && j == debut) || (i == size - 2 && j == fin))
                        {
                            Cases[i, j] = (GameObject)Instantiate<GameObject>(Case);
                            Cases[i, j].name = "Case" + i + j;
                        }
                        else
                        {
                            Cases[i, j] = (GameObject)Instantiate<GameObject>(Block);
                            Cases[i, j].name = "Block";
                        }
                    }
                    Cases[i, j].transform.parent = this.transform;
                    //Scale                
                    Cases[i, j].transform.localScale = scale;

                    //position
                    Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(1, 1)); // bas gauche de l'écran                
                    v.x += (0.6f + i) * Cases[i, j].transform.localScale.x;
                    //v.y += (0.6f + j + (height - grilleHeight) / 2) * c.transform.localScale.y;
                    v.y += (0.6f + j) * Cases[i, j].transform.localScale.y;
                    v.z = 0;
                    Cases[i, j].transform.position = v;

                    Cases[i, j].GetComponent<Case>().position = new Vector2Int(i, j);
                }
            }
            CasesGeneration();

            caseTab = PathFinding(Cases[1, positionDebut.y].GetComponent<Case>());
        }
        PipeManager.current.LoadQuantity();
    }

    public void CasesGeneration()
    {
        Case empty = new GameObject().AddComponent<Case>();
        empty.InitCase(false, false);
        foreach (GameObject g in Cases)
        {
            Case c = g.GetComponent<Case>();

            //Init objectif et walkable
            if (c.t == CaseType.Case)
            {
                if (c.position == new Vector2Int(size - 2, positionFin.y))
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
            
            //Horizontal
            if (c.position.x == 0)
            {
                c.voisines[0] = empty;
                c.voisines[2] = Cases[c.position.x + 1, c.position.y].GetComponent<Case>();
            }
            else if (c.position.x == size - 1)
            {
                c.voisines[0] = Cases[c.position.x - 1, c.position.y].GetComponent<Case>();
                c.voisines[2] = empty;
            }
            else
            {
                c.voisines[0] = Cases[c.position.x - 1, c.position.y].GetComponent<Case>();
                c.voisines[2] = Cases[c.position.x + 1, c.position.y].GetComponent<Case>();
            }

            //Vertical

            if (c.position.y == 0)
            {
                c.voisines[1] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
                c.voisines[3] = empty;

            }
            else if (c.position.y == size - 1)
            {
                c.voisines[1] = empty;
                c.voisines[3] = Cases[c.position.x, c.position.y - 1].GetComponent<Case>();
            }
            else
            {
                c.voisines[1] = Cases[c.position.x, c.position.y + 1].GetComponent<Case>();
                c.voisines[3] = Cases[c.position.x, c.position.y - 1].GetComponent<Case>();
            }
        }
        LinkedList<int> casesTab = PathFinding(Cases[1,positionDebut.y].GetComponent<Case>());        
        CalculateQuantity(casesTab);
    }

    public void CalculateQuantity(LinkedList<int> casesTab)
    {
        PipeManager.current.quantity= new int[6];
        casesTab.AddFirst(2);
        casesTab.AddLast(2);
        LinkedListNode<int> current = casesTab.First;
        
        while (current != casesTab.Last)
        {
            if (current.Value == 0 && current.Next.Value == 0)
            {
                PipeManager.current.quantity[0] += 1;
            }
            else if (current.Value == 0 && current.Next.Value == 1)
            {
                PipeManager.current.quantity[3] += 1;
            }
            else if (current.Value == 0 && current.Next.Value == 3)
            {
                PipeManager.current.quantity[4] += 1;
            }
            else if (current.Value == 1 && current.Next.Value == 0)
            {
                PipeManager.current.quantity[5] += 1;//OK
            }
            else if (current.Value == 1 && current.Next.Value == 1)
            {
                PipeManager.current.quantity[1] += 1;
            }
            else if (current.Value == 1 && current.Next.Value == 2)
            {
                PipeManager.current.quantity[4] += 1;//OK
            }
            else if (current.Value == 2 && current.Next.Value == 1)
            {
                PipeManager.current.quantity[3] += 1;
            }
            else if (current.Value == 2 && current.Next.Value == 2)
            {
                PipeManager.current.quantity[0] += 1;
            }
            else if (current.Value == 2 && current.Next.Value == 3)
            {
                PipeManager.current.quantity[5] += 1;
            }
            else if (current.Value == 3 && current.Next.Value == 0)
            {
                PipeManager.current.quantity[3] += 1;
            }
            else if (current.Value == 3 && current.Next.Value == 2)
            {
                PipeManager.current.quantity[2] += 1;
            }
            else if (current.Value == 3 && current.Next.Value == 3)
            {
                PipeManager.current.quantity[1] += 1;
            }
            current = current.Next;
        }
        PipeManager.current.LoadQuantity();
    }

    public LinkedList<int> PathFinding(Case debut)
    {
        LinkedList<Case> marked = new LinkedList<Case>();
        List<Case> verified = new List<Case>();
        LinkedList<LinkedList<int>> paths = new LinkedList<LinkedList<int>>();
        LinkedList<int> finalpath = new LinkedList<int>();

        bool found = false;

        marked.AddFirst(debut);

        paths.AddFirst(new LinkedList<int>());

        while (!found && marked.Count != 0)
        {
            Case current = marked.First.Value;
            for (int i = 0; i < 4; i++)
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


    void SetScale()
    {
        float height = Camera.main.orthographicSize * 2.0f; //hauteur
        float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height; //largeur
        float caseWidth = width / (size * 2);
        float grilleHeight = caseWidth * size;
        scale = 0.8f * new Vector3(caseWidth, caseWidth, 1); // 1/8 de la largeur
    }

    public void Regenerate()
    {
        PipeManager.current.Unselect();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Destroy(Cases[i, j]);
            }
        }
        Generation();
    }

    public void CheckWin()
    {
        Case debut = Cases[1,positionDebut.y].GetComponent<Case>();
        Case fin = Cases[size-1, positionFin.y].GetComponent<Case>();
        int dir = 2;
        Case prev = null;
        Case current = debut;
        Case next = null;

        if (debut.p==null)
        {
            Debug.Log("no");
            return;
        }
        else
        {
            prev = current;
            if (current.p.pipeType==PipeManager.PipeType.Horizontal)
            {
                Debug.Log(current.voisines[2]);
                next = current.voisines[2];
                dir = 2;

                Debug.Log(current);
                Debug.Log(dir);
            }
            else if (current.p.pipeType == PipeManager.PipeType.TopRight)
            {
                Debug.Log(current.voisines[3]);
                next = current.voisines[3];
                dir = 3;

                Debug.Log(current);
                Debug.Log(dir);
            }
            else if (current.p.pipeType == PipeManager.PipeType.BottomRight)
            {
                Debug.Log(current.voisines[1]);
                next = current.voisines[1];
                dir = 1;
                Debug.Log(current);
                Debug.Log(dir);
            }
            else
            {
                Debug.Log("no2");
                return;
            }
        }
        Debug.Log("next : " + next);
        while (current!=null && current.p!=null)
        {
            prev = current;
            current = next;
            Debug.Log("while");
            Debug.Log("while");
            if (dir == 0)
            {
                Debug.Log("0");
                prev = current;
                if (current.p.pipeType == PipeManager.PipeType.Horizontal)
                {
                    next = Cases[current.position.x -1, current.position.y].GetComponent<Case>();
                    dir = 0;
                }
                else if (current.p.pipeType == PipeManager.PipeType.TopLeft)
                {
                    next = Cases[current.position.x, current.position.y-1].GetComponent<Case>();
                    dir = 3;
                }
                else if (current.p.pipeType == PipeManager.PipeType.BottomLeft)
                {
                    next = Cases[current.position.x, current.position.y + 1].GetComponent<Case>();
                    dir = 1;
                }
                else
                {
                    Debug.Log("no3");
                    return;
                }
            }
            else if (dir==1)
            {
                Debug.Log("1");
                prev = current;
                if (current.p.pipeType == PipeManager.PipeType.Vertical)
                {
                    next = Cases[current.position.x, current.position.y + 1].GetComponent<Case>();
                    dir = 1;
                }
                else if (current.p.pipeType == PipeManager.PipeType.TopLeft)
                {
                    next = Cases[current.position.x + 1, current.position.y].GetComponent<Case>();
                    dir = 2;
                }
                else if (current.p.pipeType == PipeManager.PipeType.TopRight)
                {
                    next = Cases[current.position.x - 1, current.position.y].GetComponent<Case>();
                    dir = 0;
                }
                else
                {
                    Debug.Log("no3");
                    return;
                }
            }
            else if (dir == 2)
            {
                Debug.Log("2");
                prev = current;
                if (current.p.pipeType == PipeManager.PipeType.Horizontal)
                {
                    next = Cases[current.position.x + 1, current.position.y].GetComponent<Case>();
                    dir = 2;
                }
                else if (current.p.pipeType == PipeManager.PipeType.BottomRight)
                {
                    next = Cases[current.position.x, current.position.y + 1].GetComponent<Case>();
                    dir = 1;
                }
                else if (current.p.pipeType == PipeManager.PipeType.TopRight)
                {
                    next = Cases[current.position.x, current.position.y - 1].GetComponent<Case>();
                    dir = 3;
                }
                else
                {
                    Debug.Log("no4");
                    return;
                }
            }
            else if (dir == 3)
            {
                Debug.Log("3");
                prev = current;
                if (current.p.pipeType == PipeManager.PipeType.Vertical)
                {
                    next = Cases[current.position.x, current.position.y - 1].GetComponent<Case>();
                    dir = 3;
                }
                else if (current.p.pipeType == PipeManager.PipeType.BottomRight)
                {
                    next = Cases[current.position.x + 1, current.position.y].GetComponent<Case>();
                    dir = 2;
                }
                else if (current.p.pipeType == PipeManager.PipeType.BottomLeft)
                {
                    next = Cases[current.position.x - 1, current.position.y].GetComponent<Case>();
                    dir = 0;
                }
                else
                {
                    Debug.Log("no5");
                    return;
                }
            }
        }
        

        if (prev == Cases[size - 2, positionFin.y] && current==fin)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log(" : ");
        }
    }

    public void Update()
    {
        //CheckWin();
       
    }
}
