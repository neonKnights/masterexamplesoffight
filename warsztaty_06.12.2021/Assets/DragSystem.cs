using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragSystem : MonoBehaviour
{
    [SerializeField]
    private Camera headCamera;
    [SerializeField]
    private Transform slot;
    [SerializeField]
    private float velocity;

    private DragableItem item;

    void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnShoot(InputValue inputSystem)
    {
        if (this.item != null) {
            DropItem();
            return;
        }

        Ray ray = headCamera.ViewportPointToRay(new Vector2(.5f, .5f));
	    RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f)) {
		    DragableItem item = hit.transform.GetComponent<DragableItem>();
		    if (item != null) {
                DragItem(item);
		    }
	    }
    }

    void DragItem(DragableItem item) {
        this.item = item; 
        item.Rigidbody.isKinematic = true;
        item.Rigidbody.velocity = Vector3.zero;
        item.transform.parent = slot;
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
    }

    void DropItem() {
        item.transform.parent = null;
        item.Rigidbody.isKinematic = false;
        item.Rigidbody.velocity = slot.transform.rotation*Vector3.forward*velocity;
        item = null;
    }
}
