using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndRotate : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{


    /// <summary>
    /// Array of Vector3 representing angles and the state these angles correspond to. 
    /// </summary>
    [SerializeField] private Vector3[] angleIntervals;

    /// <summary>
    /// Angle of the dragging object when OnBeginDrag is called.
    /// </summary>
    /// 
    private float onBeginDrag;

    /// <summary>
    /// Angle of the dragging object when OnPointerDown is called.
    /// </summary>
    private float onPointerDown = 0f;

    private StateManager stateManager;

    private void Start()
    {
        stateManager = StateManager.instance;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)transform.position;
        onBeginDrag = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - (Vector2)transform.position;
        float angle = (onBeginDrag + (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - onPointerDown) + 180;

        // Apply the transformation on this object.
        transform.rotation = Quaternion.AngleAxis(angle, this.transform.forward);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Communicate to the StateManager which state it should be in based on where this object's angle is.
        float angle = transform.eulerAngles.z;
        if (angle > 180)
        {
            angle -= 360f;
        }
        Debug.Log("angle:" + transform.eulerAngles.z);
        foreach (Vector3 interval in angleIntervals)
        {
            if (interval.x < angle && angle <= interval.y)
            {
                stateManager.GoToState((int)interval.z);
                return;
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onPointerDown = transform.eulerAngles.z;
    }


}
