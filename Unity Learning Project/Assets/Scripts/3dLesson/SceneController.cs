using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    [SerializeField] private GameObject targetPrefab;
    private GameObject _target;

	
	// Update is called once per frame
	void Update () {
	    if(_target == null)
        {
            _target = Instantiate(targetPrefab) as GameObject;
            _target.transform.position = new Vector3(1, 0.5f, 1);
            float angle = Random.Range(0, 360);
            _target.transform.Rotate(0, angle, 0);
        }
	}
}
