using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    public float scale = 0f;
    public float diff = 0f;

    public void scaleModel(float newScale){
        if(newScale > scale){
            diff = newScale - scale;
            transform.localScale += new Vector3(0.05F*diff, 0.05F*diff, 0.05F*diff);
        }
        else{
            diff = scale - newScale;
            transform.localScale -= new Vector3(0.05F*diff, 0.05F*diff, 0.05F*diff);
        }
        scale = newScale;
    }
}
