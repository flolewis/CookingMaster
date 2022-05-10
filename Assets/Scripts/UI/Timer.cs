using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Timer : MonoBehaviour
{
    public float timer;
    public Slider slider;
    public UnityEvent onStart,onEnd;
    private bool isRunning;
    private IEnumerator t;
    public bool startOnAwake = true,ended = false;
    private void Start()
    {
        slider.value = 0;
        t = TimerCoroutine();
        if (startOnAwake)
        {
            StartTimer();
        }
    }
    private void Update()
    {
        if (isRunning) {
            slider.value += Time.deltaTime / timer;
        }
    }
    public void StartTimer()
    {
        isRunning = false;
        StopCoroutine(t);
        slider.value = 0;
        t = TimerCoroutine();
        StartCoroutine(t);
    }
    public IEnumerator TimerCoroutine()
    {
            onStart.Invoke();
            isRunning = true;
            yield return new WaitForSeconds(timer);
            isRunning = false;
            ended = true;
            onEnd.Invoke();
    }
}
