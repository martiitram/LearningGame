using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObjetBehaviour : MonoBehaviour
{
    private GameObject goalObject;

    // Start is called before the first frame update
    void Start()
    {
        goalObject = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        goalObject.transform.Rotate(new Vector3(0,1,0), Space.World);
    }
}
