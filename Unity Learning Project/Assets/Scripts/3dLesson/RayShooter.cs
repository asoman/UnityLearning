using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera _cam;

	// Use this for initialization
	void Start () {
        _cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_cam.pixelWidth / 2, _cam.pixelHeight / 2, 0);
            Ray ray = _cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                StartCoroutine(SphereIndicator(hit.point));
        }
	}

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
