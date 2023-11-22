using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateFindCollider : MonoBehaviour
{
    public GameObject gate;

    private bool isOpened = true;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && isOpened == true)
        {
            gate.SetActive(false);
            isOpened = false;
        }
        else if (other.CompareTag("Character") && isOpened == false)
        {
            gate.SetActive(true);
            isOpened = true;
        }
    }
}