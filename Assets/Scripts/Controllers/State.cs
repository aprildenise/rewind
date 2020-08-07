using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    /// <summary>
    /// The StateManager that this state belongs to.
    /// </summary>
    private StateManager manager;

    private void Start()
    {
        manager = transform.parent.GetComponent<StateManager>();
    }
}
