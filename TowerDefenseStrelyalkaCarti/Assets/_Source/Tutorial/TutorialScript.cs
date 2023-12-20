using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int panelIndex = 0;
    private float waitTime = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            if (i == panelIndex)
            {
                panels[i].SetActive(true);
            }
            else
            {
                panels[i].SetActive(false);
            }
        }

        if (panelIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                panelIndex++;
            }
        }
        else if (panelIndex == 1)
        {
            if (waitTime <= 0)
            {
                waitTime = 3f;
                panelIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (panelIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelIndex++;
            }
        }
        else if (panelIndex == 3)
        {
            if (waitTime <= 0)
            {
                panelIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (panelIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelIndex++;
            }
        }
        else if (panelIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelIndex++;
            }
        }
    }
}
