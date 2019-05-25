using UnityEngine;

public class RaycastReporter : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 wp = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit hit;
        }
    }
}