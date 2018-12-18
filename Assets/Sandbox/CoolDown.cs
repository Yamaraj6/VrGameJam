using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDown : MonoBehaviour
{
    public GameObject action;
    public GameObject loaderBracelet;
    public float coolDownTime;

    private float lastCast;
    private bool able;
    private Color initialColor;

    private void Start()
    {
        Color initialColor = loaderBracelet.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastCast + coolDownTime) < Time.time)
        {
            able = true;
        }
        else
        {
            float progress = (Time.time - lastCast) / coolDownTime;
            loaderBracelet.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.black, initialColor, progress);
            able = false;
        }
    }

    void Wait()
    {
        able = false;
        lastCast = Time.time;
    }
}
