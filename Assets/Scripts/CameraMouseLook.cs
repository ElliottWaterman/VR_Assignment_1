using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMouseLook : MonoBehaviour
{
    GameObject player;

    private GameObject lookingAtObject = null;
    public float lookingDistance = 8.0f;

    private bool userInteract;

    public Text interactText;

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;
    private Vector2 scalingVector;

    // Start is called before the first frame update
    void Start()
    {
        // Get the player/capsule object as it is a parent of the 
        // camera (where this script is attached)
        player = this.transform.parent.gameObject;

        float scale = sensitivity * smoothing;
        scalingVector = new Vector2(scale, scale);
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, scalingVector);

        // Linear interpretation of movement, moves smoothly between two points
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // total mouse movement so far
        mouseLook += smoothV;
        // Stop mouse movement in Y axis (up/down) from going past straight up and down
        // by setting min and max between -90 and 90 degrees
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90, 90);

        // Mouse movement in Y (up/down) rotates the camera AROUND the X (right) axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        // Mouse movement in X (left/right) rotates the PLAYER AROUND the player's Y (up/down) axis
        // Uses the player's/capsule's axis so the camera can be off aligned and stay that way
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

        // Check what player is looking at:
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, lookingDistance))
        {
            lookingAtObject = hit.collider.gameObject;

            // Check object looked at for usable (interact)
            UsableObject interactObject = lookingAtObject.GetComponent<UsableObject>();

            if (interactObject != null)
            {
                CompleteInteractActions(interactObject);
            }
            else
            {
                // try interactable PARENT object
                UsableObject interactParentObject = lookingAtObject.GetComponentInParent<UsableObject>();

                if (interactParentObject != null)
                {
                    CompleteInteractActions(interactParentObject);
                }
                else
                {
                    interactText.enabled = false;
                }
            }
        }
        else
        {
            lookingAtObject = null;

            interactText.enabled = false;
        }
    }

    private void CompleteInteractActions(UsableObject interactObject)
    {
        Debug.Log("Called Display Text on " + interactObject.name);
        // Show interact text on the screen
        interactObject.DisplayText();

        // Player has interacted with object using 'E'
        if (Input.GetKeyDown(interactObject.GetInteractKey()))
        {
            Debug.Log("Called On Use: " + interactObject.name);
            interactObject.OnUse();
        }
    }

    public GameObject getLookingAtObject()
    {
        return lookingAtObject;
    }
}
