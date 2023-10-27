using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFindCollider : MonoBehaviour
{
    public GameObject gate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Trigger();
    }

    public void Trigger()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (gate.activeInHierarchy == false)
            {
                gate.SetActive(true);
            }
            else if (gate.activeInHierarchy == true)
            {
                gate.SetActive(false);
            }
        }
    }
}
