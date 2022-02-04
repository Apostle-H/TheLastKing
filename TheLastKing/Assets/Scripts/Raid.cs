using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raid : Timer
{
    [SerializeField] private Wave[] waves;

    private int waveIndex = 0;
    private bool end;

    protected override void Start()
    {
        timerImage = GetComponent<Image>();

        timeToFill = waves[waveIndex].Time;
        timeCounter = timeToFill;
    }

    protected override void Update()
    {
        timeCounter -= Time.deltaTime;
        timerImage.fillAmount = timeCounter / timeToFill;

        if (timeCounter <= 0 && !end)
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        timeCounter = 0;
        HQ.War(waves[waveIndex].EnemiesAmount);
        NextWave();
    }

    public void NextWave()
    {
        if (++waveIndex < waves.Length)
        {
            timeToFill = waves[waveIndex].Time;
            timeCounter = timeToFill;
        }
        else
        {
            end = true;
            HQ.Win();
        }
    }
}
