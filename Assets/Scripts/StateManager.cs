using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public State[] states;

    private int currentStateIndex = 0;
    [SerializeField] private State currentState;

    #region Singleton
    public static StateManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    #endregion

    public bool GoToState(int index)
    {
        Debug.Log(index);

        if (currentStateIndex == index) return false;

        // Turn off the current state.
        currentState.gameObject.SetActive(false);

        // Set the new state.
        currentState = states[index];
        currentStateIndex = index;
        currentState.gameObject.SetActive(true);

        return true;
    }
}
