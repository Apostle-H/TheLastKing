using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Raid : Timer
{
    [SerializeField] private Wave[] Waves;
    [SerializeField] private TextMeshProUGUI WaveCounter;
    [SerializeField] private TextMeshProUGUI NextWaveEnemyAmount;

    private int WaveIndex = 0;
    private bool End;

    protected override void Start()
    {
        TimeToFill = Waves[WaveIndex].time;
        TimeCounter = TimeToFill;

        if (Waves.Length > 0)
        {
            WaveCounter.text = (WaveIndex + 1).ToString() + " I " + Waves.Length.ToString();
            NextWaveEnemyAmount.text = Waves[WaveIndex].enemiesAmount.ToString();
        }
    }

    protected override void Update()
    {
        if (!Pause.isPaused)
        {
            TimeCounter -= Time.deltaTime;
            TimerImage.fillAmount = TimeCounter / TimeToFill;
        }

        if (TimeCounter <= 0 && !End)
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        TimeCounter = 0;
        HQ.War(Waves[WaveIndex].enemiesAmount);
        NextWave();
    }

    public void NextWave()
    {
        if (++WaveIndex < Waves.Length)
        {
            WaveCounter.text = "wave" + (WaveIndex + 1).ToString() + "I" + Waves.Length.ToString();
            NextWaveEnemyAmount.text = "enemies" + Waves[WaveIndex].enemiesAmount.ToString();

            TimeToFill = Waves[WaveIndex].time;
            TimeCounter = TimeToFill;
        }
        else
        {
            End = true;
            HQ.Win();
        }
    }
}
