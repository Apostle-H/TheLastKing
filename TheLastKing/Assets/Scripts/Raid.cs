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
        TimeToFill = waves[waveIndex].time;
        TimeCounter = TimeToFill;
    }

    protected override void Update()
    {
        if (!Pause.isPaused)
        {
            TimeCounter -= Time.deltaTime;
            TimerImage.fillAmount = TimeCounter / TimeToFill;
        }

        if (TimeCounter <= 0 && !end)
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        TimeCounter = 0;
        HQ.War(waves[waveIndex].enemiesAmount);
        NextWave();
    }

    public void NextWave()
    {
        if (++waveIndex < waves.Length)
        {
            TimeToFill = waves[waveIndex].time;
            TimeCounter = TimeToFill;
        }
        else
        {
            end = true;
            HQ.Win();
        }
    }
}
