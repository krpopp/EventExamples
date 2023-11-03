using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescribeText : MonoBehaviour
{

    [SerializeField]
    TMP_Text describeText;

    private void Start()
    {
        describeText.text = "";
    }

    public void ShowText()
    {
        GameObject obj = CursorManager.objTouched;
        if (obj != null)
        {
            //access the object's description text via the IClickable interface
            describeText.text = obj.GetComponent<IClickable>().DescriptionText;
        }
        else
        {
            describeText.text = "";
        }
        
    }
}
