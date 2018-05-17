using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitcher : MonoBehaviour
{
    public GameObject unloadBox;
    public GameObject loadBox;
    public GameObject pieza1;
    public GameObject pieza2;
    public GameObject pieza3;
    public PlayerBehaviour player;
    //public float timeCounter;
    //public bool isActive;

    void Start ()
    {
        loadBox.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}
    /*
    public void Update()
    {
        if(isActive == true)
        {
            timeCounter++;
            ActivePieces();
        }
    }*/

    public void Switch()
    {
        unloadBox.SetActive(false);
        loadBox.SetActive(true);

        //isActive = true;

        Vector2 dir = loadBox.transform.position - player.transform.position;
        dir.Normalize();
        pieza1.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);
        pieza2.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);
        pieza3.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);
    }
    /*
    public void ActivePieces()
    {
        if(timeCounter >= 300)
        {
            Debug.Log("desactivePieces");
            pieza1.SetActive(false);
            pieza2.SetActive(false);
            pieza3.SetActive(false);
        }
    }*/
}
