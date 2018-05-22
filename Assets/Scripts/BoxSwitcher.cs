using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSwitcher : MonoBehaviour
{
    public GameObject unloadBox;
    public GameObject loadBox;
    public GameObject pieza1;
    public Animator anim1;
    public GameObject pieza2;
    public Animator anim2;
    public GameObject pieza3;
    public Animator anim3;
    public PlayerBehaviour player;

    void Start ()
    {
        loadBox.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
	}

    public void Switch()
    {
        unloadBox.SetActive(false);
        loadBox.SetActive(true);

        Vector2 dir = loadBox.transform.position - player.transform.position;
        dir.Normalize();
        pieza1.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);
        pieza2.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);
        pieza3.GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);

        anim1.SetTrigger("DestroyPiece");
        anim2.SetTrigger("DestroyPiece");
        anim3.SetTrigger("DestroyPiece");
        Destroy(loadBox, 1);
    }
}
