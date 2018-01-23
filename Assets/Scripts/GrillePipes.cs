using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillePipes : MonoBehaviour
{

    int size;
    public GameObject PipeFin;
    public GameObject PipeDebut;
    public GameObject Case;
    public GameObject Block;


    public void Start()
    {
        size = 4;   
        Generation();       
    }

    public void Generation()
    {
        int debut = Random.Range(0, size);
        int fin = Random.Range(0, size);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {                
                GameObject c;
                if (i == 0 && j == debut)
                {
                    c = Instantiate<GameObject>(PipeDebut);
                    c.name = "Debut";
                }
                else if (i == size-1 && j == fin)
                {
                    c = Instantiate<GameObject>(PipeFin);
                    c.name = "Fin";
                }
                else
                {
                    c = Instantiate<GameObject>(Case);
                    c.name = "Case" + i + j;
                }
                c.transform.parent = this.transform;
                //Scale
                float height = Camera.main.orthographicSize * 2.0f; //hauteur
                float width = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height; //largeur
                float caseWidth = width /(size*2);
                float grilleHeight = caseWidth * size;
                c.transform.localScale = new Vector3(caseWidth, caseWidth, -1); // 1/8 de la largeur

                //position
                Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(1, 1)); // bas gauche de l'écran                
                v.x += (0.5f + i)*c.transform.localScale.x;
                v.y += (0.5f + j + (height-grilleHeight)/2) *c.transform.localScale.y;
                v.z =0;
                c.transform.position=v;
                
            }
        }
    }
}
