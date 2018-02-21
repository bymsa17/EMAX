using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBehaviour : MonoBehaviour
{
    public BalancePlateBehaviour platoIzquierdo;
    public BalancePlateBehaviour platoDerecho;

    //public Collider2D izquierda;
    //public Collider2D derecha;

    public int weight;
    public float maxDistance;

    public void Update()
    {
        if (weight == 0)
        {
            if (platoIzquierdo.gameObject.transform.localPosition.y > 0.05f)
            {
                platoIzquierdo.gameObject.transform.position -= new Vector3(0, 2, 0) * Time.deltaTime / 2;
            }
            else if (platoIzquierdo.gameObject.transform.localPosition.y < -0.05f)
            {
                platoIzquierdo.gameObject.transform.position += new Vector3(0, 2, 0) * Time.deltaTime / 2;
            }
            else platoIzquierdo.gameObject.transform.localPosition = new Vector3(platoIzquierdo.gameObject.transform.localPosition.x, 0, 0);
        }

        weight = platoIzquierdo.weight - platoDerecho.weight;
        if(weight > 3) weight = 3;
        else if(weight < -3) weight = -3;

        if(((platoIzquierdo.gameObject.transform.localPosition.y > -maxDistance) && (weight > 0)) || ((platoIzquierdo.gameObject.transform.localPosition.y < maxDistance) && (weight < 0)))
        {
            platoIzquierdo.gameObject.transform.position -= new Vector3(0, weight, 0) * Time.deltaTime / 2;
        }

        platoDerecho.gameObject.transform.localPosition = new Vector3(platoDerecho.gameObject.transform.localPosition.x, -platoIzquierdo.gameObject.transform.localPosition.y, platoDerecho.gameObject.transform.localPosition.z);
    }
    
}
