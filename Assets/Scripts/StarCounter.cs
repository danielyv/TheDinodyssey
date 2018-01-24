using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarCounter : MonoBehaviour {
    Text instruction;
    void Start()
    {
        instruction = GetComponent<Text>();
        instruction.text = "0/26 étoiles";
    }

    // Update is called once per frame
    void Update () {
        instruction.text = PlatformerPlayer.stars+"/26 étoiles";

    }
}
