using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExpTrace : MonoBehaviour
{
    public static ExpTrace instance;
    [Header("Set in dinamically")]
    private Slider _slider;

    private void OnEnable()
    {
        PlayerEventManager.OnUpdatedPoints += ExpBarUpdate;
        PlayerEventManager.OnSetedTotalPoint += SetMaxValue;
    }
    private void OnDisable()
    {
        PlayerEventManager.OnUpdatedPoints -= ExpBarUpdate;
        PlayerEventManager.OnSetedTotalPoint -= SetMaxValue;
    }

    // Use this for initialization

    private void Awake()
    {
        instance = this;

        _slider = GetComponent<Slider>();
    }

    public void ExpBarUpdate(int totalPoints)
    {
        //image.fillAmount = totalPoints / 100f;
        _slider.value = totalPoints;
    }

    public void SetMaxValue(int value)
    {
        _slider.maxValue = value;
    }
}