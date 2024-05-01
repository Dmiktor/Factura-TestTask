using System;
using UnityEngine;

public class InputValidator : MonoBehaviour
{
    public Action<Vector2> OnTouchMoved;
    public Action OnFirstTouch;

    public void DoUpdate()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);
            if (touch0.phase == TouchPhase.Began)
            {
                OnFirstTouch?.Invoke();
            }
        }
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);
            if (touch0.phase == TouchPhase.Moved)
            {
                OnTouchMoved?.Invoke(touch0.deltaPosition);
            }

        }
    }
}
