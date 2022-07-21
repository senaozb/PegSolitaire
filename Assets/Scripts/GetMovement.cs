using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetMovement : MonoBehaviour
{
    //This class adds a listener to the pegs
    public UnityEvent unityEvent = new UnityEvent();
    public GameObject button;

    void Start()
    {
        button = this.gameObject;
        unityEvent.AddListener(buttonAction);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }

    void buttonAction()
    {
        CreateBoard.counter++;

        //Get the first and second pegs' coordinates in an order
        if (CreateBoard.counter % 2 != 0)
        {
            Validation.firstY = gameObject.transform.position.z/2;
            Validation.firstX = gameObject.transform.position.x/2;
        }
        else
        {
            Validation.secondY = gameObject.transform.position.z/2; 
            Validation.secondX = gameObject.transform.position.x/2;
            gameObject.GetComponent<Validation>().validate();
        }
    }
}
