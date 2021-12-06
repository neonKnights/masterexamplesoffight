using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragSystem : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector2(.5f, .5f));
	RaycastHit hit;
	if (Physics.Raycast(ray, out hit, 5f)) {
		DragableItem item = hit.transform.GetComponent<DragableItem>();
		if (item != null) {
			Debug.Log("Dragg backet");
		}
	}
    }
}
