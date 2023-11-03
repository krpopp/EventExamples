using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IClickable
{
    //comes from the IClickable interface
    //if a class uses an interface, it must use the properties and methods of that interface
    public string DescriptionText
    {
        get
        {
            return descriptionText;
        }
    }

    [SerializeField]
    string descriptionText;

    void IClickable.ShowDescription()
    {

    }
}
