using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeManager : MonoBehaviour
{

    public enum PipeType : int { Horizontal=0, Vertical=1, BottomLeft=2, BottomRight=3, TopLeft=4, TopRight=5,None=6 }

    public bool dragging;

    public static PipeManager current;

    public GameObject[] pipePrefabs;

    public int[] quantity;
    public GameObject[] uiQuantity;

    public GameObject draggingPipe;

    public void Awake()
    {        
        current = this;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Update()
    {
        if (dragging)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -2;
            draggingPipe.transform.position = pos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Unselect();
        }
    }

    public void Select(GameObject pipePrefab)
    {
        Debug.Log("prefab : " + pipePrefab);
        dragging = true;
        draggingPipe = (GameObject) Instantiate<GameObject>(pipePrefab) as GameObject;
        draggingPipe.name = "1";
        Debug.Log(draggingPipe);
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = -2;
        draggingPipe.transform.position = pos;
        draggingPipe.transform.localScale = GrillePipes.scale;        
    }

    public void Unselect()
    {
        dragging = false;
        Destroy(draggingPipe);
        draggingPipe = null;
    }

    public void AddPipe(PipeType pt)
    {
        quantity[(int)pt]+=1;
        uiQuantity[(int)pt].GetComponent<Text>().text = "" + quantity[(int)pt];
        if (quantity[(int)pt] <= 0)
        {
            uiQuantity[(int)pt].transform.parent.GetComponent<Button>().interactable = false;
        }
        else
        {
            uiQuantity[(int)pt].transform.parent.GetComponent<Button>().interactable = true;
        }
    }

    public void TakePipe(PipeType pt)
    {
        quantity[(int)pt] -= 1;
        uiQuantity[(int)pt].GetComponent<Text>().text = "" + quantity[(int)pt];
        if (quantity[(int)pt] <= 0)
        {
            uiQuantity[(int)pt].transform.parent.GetComponent<Button>().interactable = false;
        }
        else
        {
            uiQuantity[(int)pt].transform.parent.GetComponent<Button>().interactable = true;
        }
    }

    public void LoadQuantity()
    {
        for(int i=0;i<quantity.Length;i++)
        {
            uiQuantity[i].GetComponent<Text>().text = "" + quantity[i];
            if (quantity[i] == 0)
            {
                uiQuantity[i].transform.parent.GetComponent<Button>().interactable = false;
            }
            else
            {
                uiQuantity[i].transform.parent.GetComponent<Button>().interactable = true;
            }
        }
        
    }

}
