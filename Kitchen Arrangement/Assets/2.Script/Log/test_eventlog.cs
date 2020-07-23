using UnityEngine;
using VRTK;

public class test_eventlog : MonoBehaviour
{
    public void mytest(object o, ControllerInteractionEventArgs e)
    {
        print("hello");
    }
}