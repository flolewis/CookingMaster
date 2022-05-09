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
    private void Start()
    {
        slider.value = 0;
        StartCoroutine(TimerCoroutine());
    }
    private void Update()
    {
        if (isRunning) {
            slider.value += Time.deltaTime / 10;
        }
    }
    public IEnumerator TimerCoroutine()
    {
        onStart.Invoke();
        Debug.Log("Start");
        isRunning = true;
        yield return new WaitForSecondsRealtime(timer);
        isRunning = false;
        Debug.Log("End");
        onEnd.Invoke();
        slider.value = 0;
    }
}
