using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] protected HeadQuaters HQ;

    protected Button button;
    protected Image timerImage;


    [SerializeField] protected float time;
    protected float timeCounter;

    protected virtual void Start()
    {
        timerImage = GetComponent<Image>();
        button = GetComponent<Button>();
        button.interactable = false;

        timeCounter = 0;
        timerImage.fillAmount = 0;
    }

    protected virtual void Update()
    {
        timeCounter += Time.deltaTime;
        timerImage.fillAmount = timeCounter / time;
    }
}
