using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Target serve para fazer uma chamada para um método de um gameObject pela sua tag.
 **/
[System.Serializable]
public class Target
{

    public string methodName;
    public string tag;
    public Object[] args;
    public GameObject gameObjectTarget;

}
