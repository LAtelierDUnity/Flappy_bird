using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [Header("Sprite")]
    [SerializeField]
    private SpriteRenderer _daySprite;
    [SerializeField]
    private SpriteRenderer _nightSprite;

    [Header("Durées")]
    [SerializeField]
    private float _dayduration = 10f;
    [SerializeField]
    private float _nightduration = 10f;

    void Start()
    {
        StartCoroutine(DayNightLoop());
    }


    private IEnumerator DayNightLoop()
    {
        while (true)
        {
            yield return StartCoroutine(FadeSprite(_nightSprite, _daySprite, _nightduration));

            yield return StartCoroutine(FadeSprite(_daySprite,_nightSprite,_dayduration));

        }
    }

    private IEnumerator FadeSprite(SpriteRenderer fadeIn, SpriteRenderer fadeout, float duration)
    {
        fadeIn.gameObject.SetActive(true);
        fadeout.gameObject.SetActive(true);

        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;


            float t = time / duration;

            float alphaIn = Mathf.Lerp(0, 1, t);

            float alphaOut = Mathf.Lerp(1, 0, t);

            fadeIn.color = new Color (fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, alphaIn);
            fadeout.color = new Color (fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, alphaOut);

            yield return null;
        }

        fadeIn.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 1);
        fadeout.color = new Color(fadeIn.color.r, fadeIn.color.g, fadeIn.color.b, 0);
    }
}
