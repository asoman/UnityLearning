using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
            behavior.setAlive(false);
        StartCoroutine(Die());

    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75.0f, 0, 0);

        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }
}
