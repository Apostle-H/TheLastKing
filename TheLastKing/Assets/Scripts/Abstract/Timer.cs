using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Timer : MonoBehaviour
{
    [SerializeField] protected HeadQuaters HQ;

    [Header("Timer")]
    [SerializeField] protected float TimeToFill;

    [SerializeField] protected Button ActionButton;
    [SerializeField] protected Image TimerImage;
    protected float TimeCounter;

    protected virtual void Start()
    {
        TimeCounter = TimeToFill;
    }

    protected virtual void Update()
    {
        if (!Pause.isPaused)
        {
            TimeCounter += Time.deltaTime;
            TimerImage.fillAmount = TimeCounter / TimeToFill;
        }
    }
}
