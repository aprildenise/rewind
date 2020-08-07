using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public State[] states;

    private int currentStateIndex = 0;
    public State currentState { get; private set; }

    private UIController ui;


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

    private void Start()
    {
        ui = UIController.instance;
        GoToState(0);
        ui.ResetMarkings();
    }

    public bool GoToState(int index)
    {
        Debug.Log(index);

        // Turn off the current state.
        if (currentState != null)
        {
            currentState.gameObject.SetActive(false);
        }

        // Set the new state.
        currentState = states[index];
        currentStateIndex = index;
        currentState.gameObject.SetActive(true);

        // Decrease the number of clock usages.
        ui.RemoveMarking();

        return true;
    }
}
