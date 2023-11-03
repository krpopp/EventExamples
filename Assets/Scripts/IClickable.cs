using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClickable
{
    //interfaces cannot contain fields, only properties and methods
    //property for the description text
    public string DescriptionText { get; }
    //this isn't being used, just an example of what a method looks like in an interface
    public void ShowDescription();
}
