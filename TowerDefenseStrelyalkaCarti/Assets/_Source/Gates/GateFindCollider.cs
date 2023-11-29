using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GatesSystem
{
    public class GateFindCollider : MonoBehaviour
    {
        public GameObject gate;

        private bool isOpened = true;

        private bool gateState = true;
        // Start is called before the first frame update


        IEnumerator OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Character") && isOpened == true && gateState == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    gate.SetActive(false);
                    isOpened = false;
                    gateState = false;
                    yield return new WaitForSeconds(0.3f);
                    gateState = true;
                }
            }
            else if (other.CompareTag("Character") && isOpened == false && gateState == true)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    gate.SetActive(true);
                    isOpened = true;
                    gateState = false;
                    yield return new WaitForSeconds(0.3f);
                    gateState = true;
                }
            }
        }
    }
}
