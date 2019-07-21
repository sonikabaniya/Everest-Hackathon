using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
  public float speed=2f;

  public void update(){
        // transform.Rotate(0, speed*Time.deltaTime, 0);

  }

    public void rotate(float newSpeed)
    {
        speed = newSpeed;
        transform.Rotate(0,speed*Time.deltaTime, 0);
        Debug.Log(speed);
    }
}
