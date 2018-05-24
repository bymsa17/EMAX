using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject Text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.SetActive(false);
    }
}
