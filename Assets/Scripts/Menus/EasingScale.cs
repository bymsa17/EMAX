using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingScale : MonoBehaviour
{
    public enum Type { EXPO, CIRCULAR, QUAD, SINE, CUBIC, QUARTIC, QUINTIC, ELASTIC, BOUNCE, BACK };
    public Type type;

    public Vector3 iniValue;
    public Vector3 finalValue;
    public float currentTime;
    public float timeDuration;

    int n;
    public int repeat;
    public bool isActive;

    private Vector3 deltaValue;

    private void Start()
    {
        deltaValue = finalValue - iniValue;
        isActive = false;
        repeat = 2;
    }

    public void Update()
    {
        if(isActive == true)
        {
            ActiveEasing();
        }
        else if(isActive == false)// && (currentTime <= timeDuration) && (repeat == 2*n +1))
        {
            //ActiveEasing();
        }
    }

    public void ActiveEasing()
    {
        if(repeat > 0)
        {
            //EASING
            if(currentTime <= timeDuration)
            {
                Vector3 easingValue = new Vector3();
                switch(type)
                {
                    case Type.EXPO:
                        easingValue = new Vector3(Easing.ExpoEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.ExpoEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.ExpoEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.CIRCULAR:
                        easingValue = new Vector3(Easing.CircEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.CircEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.CircEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUAD:
                        easingValue = new Vector3(Easing.QuadEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.QuadEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.QuadEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.SINE:
                        easingValue = new Vector3(Easing.SineEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.SineEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.SineEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.CUBIC:
                        easingValue = new Vector3(Easing.CubicEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.CubicEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.CubicEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUARTIC:
                        easingValue = new Vector3(Easing.QuartEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.QuartEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.QuartEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.QUINTIC:
                        easingValue = new Vector3(Easing.QuintEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.QuintEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.QuintEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.ELASTIC:
                        easingValue = new Vector3(Easing.ElasticEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.ElasticEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.ElasticEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.BOUNCE:
                        easingValue = new Vector3(Easing.BounceEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.BounceEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.BounceEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    case Type.BACK:
                        easingValue = new Vector3(Easing.BackEaseOut(currentTime, iniValue.x, deltaValue.x, timeDuration),
                                                    Easing.BackEaseOut(currentTime, iniValue.y, deltaValue.y, timeDuration),
                                                    Easing.BackEaseOut(currentTime, iniValue.z, deltaValue.z, timeDuration));
                        break;
                    default:
                        break;
                }

                //DO EASING
                transform.localScale = easingValue;

                currentTime += Time.deltaTime;
                if(currentTime >= timeDuration)
                {
                    Debug.Log("EL EASING ACABA DE TERMINAR JUSTO AHORA");
                    transform.localScale = finalValue;

                    //Bucle
                    //repeat--;
                    currentTime = 0;
                    Vector3 ini = iniValue;
                    iniValue = finalValue;
                    finalValue = ini;
                    deltaValue = finalValue - iniValue;
                }
            }
            else
            {
                Debug.Log("EASING TERMINADO!");
            }
        }
    }
}
