using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Year
{
    public int month;
    public int day;
    public string season;
}
/*
 게임 내 계절의 개념을 넣으면 계절에 따라 해가 뜨고 지는 시간을 프로그램으로 조정
 */

public class SkyboxController : MonoBehaviour
{
    [SerializeField] Material skyboxMaterial;

    [SerializeField] Light sunlight;
    [SerializeField] Color sunSkyColor;
    [SerializeField] Color sunSetColor;

    [SerializeField] Light moonlight;
    [SerializeField] Color moonSkyColor;
    [SerializeField] Color moonSetColor;

    [SerializeField, Range(0, 23)] float currentHour;
    [SerializeField] float ingameTimeSpeed; //1s = ?s in-game
    [SerializeField, Range(4, 8)] int dayStartHour;
    [SerializeField, Range(18, 23)] int nightStartHour;

    public float TotalHour = 0.0f;
    float sunDuration;
    float moonDuration;

    readonly string skyColorName = "_SkyTint";

    void Start()
    {
        currentHour = 22.0f;
        RenderSettings.skybox = skyboxMaterial;
    }

    void Update() // or switch to: InvokeRepeating("~~~", 0.0f, 1.0f); (if Update is too frequent)
    {
        TimeUpdate();
        LightUpdate();
        SkyboxUpdate();
        //SeasonUpdate();
    }

    void TimeUpdate()
    {
        currentHour += ingameTimeSpeed * Time.deltaTime; //Time.deltaTime: delta-time since last frame
        TotalHour += ingameTimeSpeed * Time.deltaTime;

        if (currentHour >= 24.0f)
        {
            currentHour = 0.0f;
        }
    }

    void LightUpdate()
    {
        if (currentHour >= dayStartHour && currentHour < nightStartHour) // day
        {
            RenderSettings.sun = sunlight;

            moonlight.enabled = false;
            moonlight.intensity = 0.0f;
            moonlight.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            //낮이 끝날 때까지의 비율
            sunDuration = (currentHour - dayStartHour) / (nightStartHour - dayStartHour);

            sunlight.enabled = true;
            sunlight.transform.rotation = Quaternion.Euler(180.0f * sunDuration, 0.0f, 0.0f);

            if (sunDuration < 0.5f)
                sunlight.intensity = sunDuration * 2.0f;
            else
                sunlight.intensity = 1.0f - ((sunDuration - 0.5f) * 2.0f);
        }
        else // night
        {
            RenderSettings.sun = moonlight;

            sunlight.enabled = false;
            sunlight.intensity = 0.0f;
            sunlight.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            moonDuration = 0.0f;

            if (currentHour < dayStartHour)
                moonDuration = (currentHour + (24.0f - nightStartHour)) / ((24.0f - nightStartHour) + dayStartHour);
            else
                moonDuration = (currentHour - nightStartHour) / ((24.0f - nightStartHour) + dayStartHour);

            moonlight.enabled = true;
            moonlight.transform.rotation = Quaternion.Euler(180.0f * moonDuration, 0.0f, 0.0f);

            if (moonDuration < 0.5f)
                moonlight.intensity = moonDuration * 2.0f;
            else
                moonlight.intensity = 1.0f - ((moonDuration - 0.5f) * 2.0f);
        }
    }

    void SkyboxUpdate()
    {
        if (currentHour >= dayStartHour && currentHour < nightStartHour)
        {
            if (sunDuration < 0.5f) {
                skyboxMaterial.SetColor(skyColorName, Color.Lerp(moonSetColor, sunSkyColor, sunDuration * 2.0f));
            }
            else {
                skyboxMaterial.SetColor(skyColorName, Color.Lerp(sunSkyColor, sunSetColor, (sunDuration - 0.5f) * 2.0f));
            }
        }
        else
        {
            if (moonDuration < 0.5f) {
                skyboxMaterial.SetColor(skyColorName, Color.Lerp(sunSetColor, moonSkyColor, moonDuration * 2.0f));
            }
            else {
                skyboxMaterial.SetColor(skyColorName, Color.Lerp(moonSkyColor, moonSetColor, (moonDuration - 0.5f) * 2.0f));
            }
        }
    }
    /*
     코드 출처: <유니티 게임 프로그래밍 바이블> p86~89
     */
}
