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
        TimerImage = GetComponent<Image>();

        TimeToFill = waves[waveIndex].Time;
        TimeCounter = TimeToFill;
    }

    protected override void Update()
    {
        TimeCounter -= Time.deltaTime;
        TimerImage.fillAmount = TimeCounter / TimeToFill;

        if (TimeCounter <= 0 && !end)
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        TimeCounter = 0;
        HQ.War(waves[waveIndex].EnemiesAmount);
        NextWave();
    }

    public void NextWave()
    {
        if (++waveIndex < waves.Length)
        {
            TimeToFill = waves[waveIndex].Time;
            TimeCounter = TimeToFill;
        }
        else
        {
            end = true;
            HQ.Win();
        }
    }
}
