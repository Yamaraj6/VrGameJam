using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SkillCast : MonoBehaviour
{
    public UnityEvent action;
    public GameObject loaderBracelet;
    public float coolDownTime;

    private float lastCast;
    private bool able = false;
    private Color initialColor;

    private void Start()
    {
        able = true;
        Color initialColor = loaderBracelet.GetComponent<MeshRenderer>().materials[0].GetColor("Tint");
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
            float progress = 1 - (Time.time - lastCast) / coolDownTime;
            loaderBracelet.GetComponent<MeshRenderer>().materials[0].SetColor("Tint", Color.Lerp(Color.black, initialColor, progress));
            able = false;
        }
    }

    void Wait()
    {
        able = false;
        lastCast = Time.time;
    }
    public void UseSkill()
    {
        if (action != null && able)
        {
            action.Invoke();
            Wait();
        }
    }
}
