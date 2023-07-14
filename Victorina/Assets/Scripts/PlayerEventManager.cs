using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventManager : MonoBehaviour 
{
    public static Action <int> OnUpdatedPoints;
    public static Action <int> OnSetedTotalPoint;
    public static Action <string> onUpdatedSpeedPoints;

    public static Action<float> OnUpdatePoints { get; internal set; }
}
