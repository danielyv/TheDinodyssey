using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlatformer : MonoBehaviour {
    Transform childGO;
    // Use this for initialization
    void Start () {
		childGO = transform.parent.FindChild("Drone");
    }

    // Update is called once per frame
    void Update () {
        //Vector3 a = transform.position;
        Vector3 a = new Vector3(childGO.position.x, childGO.position.y, transform.position.z);
        transform.position = a;
    }
}
