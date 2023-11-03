using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CursorManager : MonoBehaviour
{
    //defining the delegate
    delegate void ClickDelegate();
    //create an event instance of the ClickDelegate type
    static event ClickDelegate clickAction;

    //for cursor sprite
    [SerializeField]
    Sprite baseSprite, attackSprite, pickupSprite, openSprite, blockedSprite;
    SpriteRenderer myRenderer;

    //tracks what the cursor is on
    public static GameObject objTouched;

    //delcare a Unity event (makes it visible in the inspector, need the UnityEngine.Events up top)
    public UnityEvent clickEvent;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponentInChildren<SpriteRenderer>();
        Cursor.visible = false;

        //set the clickAction event to the BaseClick method
        clickAction = BaseClick;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;

        if(Input.GetMouseButtonDown(0))
        {
            //run the click action event whenever we press the mouse button
            //will call different methods depending on context
            clickAction();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        objTouched = col.gameObject;

        //switch which method is called based on the tag of the thing we clicked
        //add the respective method so that it is called in addition to BaseClick
        switch(col.gameObject.tag)
        {
            case "ClosedChest":
                myRenderer.sprite = blockedSprite;
                clickAction += Blocked;
                break;
            case "OpenChest":
                myRenderer.sprite = openSprite;
                clickAction += Open;
                break;
            case "Potion":
                myRenderer.sprite = pickupSprite;
                clickAction += Pickup;
                break;
            case "Spider":
                myRenderer.sprite = attackSprite;
                clickAction += Attack;
                break;
            default:
                Debug.Log("touched something else");
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objTouched = null;
        myRenderer.sprite = baseSprite;

        //reset clickaction to only call BaseClick
        clickAction = BaseClick;
    }

    void BaseClick()
    {
        //invoke the clickEvent
        //this is set in the inspector
        clickEvent.Invoke();
        //Debug.Log("clicked on nothing");
    }

    void Attack()
    {
        Debug.Log("Attack");
    }

    void Pickup()
    {
        Debug.Log("Pick up item");
    }

    void Open()
    {
        Debug.Log("Open chest");
    }

    void Blocked()
    {
        Debug.Log("Cannot open chest");
    }  
}
