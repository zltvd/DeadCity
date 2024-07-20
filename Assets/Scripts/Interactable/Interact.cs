using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private Transform intPoint;
    [SerializeField] private float intPointRad;
    [SerializeField] private LayerMask intMask;
    [SerializeField] private InteractableUI intUI;
    private readonly Collider[] col = new Collider[3];
    [SerializeField] private int numFound;
    private IInteractable interactable;
    public GameObject pressE;
    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(intPoint.position, intPointRad, col, intMask);
        if (numFound > 0)
        {
            interactable = col[0].GetComponent<IInteractable>();

            pressE.SetActive(true);
            if (interactable != null) 
            {
                if (!intUI.IsDisplayed) intUI.SetUp(interactable.InteractionPromt);
                if (Input.GetKeyDown(KeyCode.E)) interactable.Interact(this);
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (intUI.IsDisplayed) intUI.Close();
        }
    }
}
