using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
    public UnityEvent[] Actions;

    public void StartAction(int actionIndex)
    {
        Actions[actionIndex].Invoke();
    }
}
