using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] protected HeadQuaters HQ;
    [SerializeField] protected float TimeToFill;

    protected Button ActionButton;
    protected Image TimerImage;
    protected float TimeCounter;

    protected virtual void Start()
    {
        TimerImage = GetComponent<Image>();
        ActionButton = GetComponent<Button>();

        TimeCounter = TimeToFill;
    }

    protected virtual void Update()
    {
        TimeCounter += Time.deltaTime;
        TimerImage.fillAmount = TimeCounter / TimeToFill;
    }
}
