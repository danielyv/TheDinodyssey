using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeManager : MonoBehaviour {

    public enum PipeType : int { None, Vertical, Horizontal, BottomLeft, BottomRight, TopLeft, TopRight }

    public bool dragging;

    public static PipeManager current;

    public GameObject[] pipePrefabs;

    public Text[] uiQuantity;

    public GameObject draggingPipe;

    public void Awake()
    {
        current = this;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            Destroy(draggingPipe);
            draggingPipe = null;
        }       
    }

    public void Select(GameObject pipePrefab)
    {
        dragging = true;
        draggingPipe=Instantiate(pipePrefab);
    }
    public void Unselect()
    {
    }


}
