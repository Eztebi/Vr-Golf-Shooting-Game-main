using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class GolfClubScript : MonoBehaviour
{ 
[SerializeField] private Transform clubPos;

[SerializeField] XRGrabInteractable grabbable;

private bool isHeld = false;





void Start()
{
    grabbable = GetComponent<XRGrabInteractable>();
    grabbable.selectEntered.AddListener(OnSelectEntered);
    grabbable.selectExited.AddListener(OnSelectExited);
}

private void OnSelectEntered(SelectEnterEventArgs args)
{
    isHeld = true;
}

private void OnSelectExited(SelectExitEventArgs args)
{
    isHeld = false;
}


private void OnCollisionEnter(Collision collision)
{
    
}

void Update()
{
    if (!isHeld)
    {

        this.transform.position = clubPos.position;
        this.transform.rotation = clubPos.rotation;
        //rb.MoveRotation(GunPos.rotation);
    }
}
}