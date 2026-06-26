using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMoveRandom : MonoBehaviour
{

     
    [Range(-100,0)]
    public float xMinRang=0;
    [Range(0, 100)]
    public float xMaxRang=0;
    [Range(-100, 0)]
    public float yMinRang=0;
    [Range(0, 100)]
    public float yMaxRang=0;


    private Vector3 initialPos;//record the initial position of the object

    
    private void Awake()
    {
       AssingRandom();
    }
    [ContextMenu("Random Pos")]
    public void AssingRandom()
    {
        foreach (Transform a in this.transform)
        {
            float randomX = Random.Range(xMinRang, xMaxRang);
            float randomY = Random.Range(yMinRang, yMaxRang);
            a.transform.localPosition = new Vector3(randomX, randomY, 0);
        }
        transform.GetChild(0).localPosition = Vector3.zero;
    }
        
}

