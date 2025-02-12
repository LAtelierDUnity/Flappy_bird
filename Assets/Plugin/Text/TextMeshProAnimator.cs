using UnityEngine;
using TMPro;

public enum AnimationType
{
    Wave,
    Spin,
    Pulse,
    Slide,
    Fade,
    VerticalWave,
    Shake,
    ColorCycle
}

public class TextMeshProAnimator : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public AnimationType animationType = AnimationType.Wave;

    [Header("Animation Parameters")]
    public float amplitude = 10f; // Amplitude de l'animation
    public float frequency = 1f; // Fréquence de l'animation
    public float speed = 1f; // Vitesse de l'animation

    private TMP_TextInfo textInfo;
    private TMP_MeshInfo[] cachedMeshInfo;

    void Start()
    {
        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        textMeshPro.ForceMeshUpdate();
        textInfo = textMeshPro.textInfo;
        cachedMeshInfo = textInfo.CopyMeshInfoVertexData();
    }

    void Update()
    {
        switch (animationType)
        {
            case AnimationType.Wave:
                AnimateWave();
                break;
            case AnimationType.Spin:
                AnimateSpin();
                break;
            case AnimationType.Pulse:
                AnimatePulse();
                break;
            case AnimationType.Slide:
                AnimateSlide();
                break;
            case AnimationType.Fade:
                AnimateFade();
                break;
            case AnimationType.VerticalWave:
                AnimateVerticalWave();
                break;
            case AnimationType.Shake:
                AnimateShake();
                break;
            case AnimationType.ColorCycle:
                AnimateColorCycle();
                break;
        }
    }

    void AnimateWave()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            float offset = i * frequency;
            float wave = Mathf.Sin((Time.time * speed) + offset) * amplitude;

            for (int j = 0; j < 4; j++)
            {
                destinationVertices[vertexIndex + j].y = sourceVertices[vertexIndex + j].y + wave;
            }
        }

        ApplyMeshChanges();
    }

    void AnimateSpin()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            Vector3 center = (sourceVertices[vertexIndex] + sourceVertices[vertexIndex + 2]) / 2;
            float angle = Time.time * speed + i * frequency;

            for (int j = 0; j < 4; j++)
            {
                Vector3 relativePos = sourceVertices[vertexIndex + j] - center;
                relativePos = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg) * relativePos;
                destinationVertices[vertexIndex + j] = center + relativePos;
            }
        }

        ApplyMeshChanges();
    }

    void AnimatePulse()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            Vector3 center = (sourceVertices[vertexIndex] + sourceVertices[vertexIndex + 2]) / 2;
            float scale = 1 + Mathf.Sin(Time.time * speed + i * frequency) * amplitude;

            for (int j = 0; j < 4; j++)
            {
                Vector3 relativePos = sourceVertices[vertexIndex + j] - center;
                relativePos *= scale;
                destinationVertices[vertexIndex + j] = center + relativePos;
            }
        }

        ApplyMeshChanges();
    }

    void AnimateSlide()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            float offset = Mathf.Sin(Time.time * speed + i * frequency) * amplitude;
            for (int j = 0; j < 4; j++)
            {
                destinationVertices[vertexIndex + j].x = sourceVertices[vertexIndex + j].x + offset;
            }
        }

        ApplyMeshChanges();
    }

    void AnimateFade()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Color32[] vertexColors = textInfo.meshInfo[materialIndex].colors32;

            byte alpha = (byte)(Mathf.Sin(Time.time * speed + i * frequency) * 127 + 128);
            for (int j = 0; j < 4; j++)
            {
                vertexColors[vertexIndex + j].a = alpha;
            }
        }

        ApplyColorChanges();
    }

    void AnimateVerticalWave()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            float offset = i * frequency;
            float wave = Mathf.Sin((Time.time * speed) + offset) * amplitude;

            for (int j = 0; j < 4; j++)
            {
                destinationVertices[vertexIndex + j].y = sourceVertices[vertexIndex + j].y + wave;
            }
        }

        ApplyMeshChanges();
    }

    void AnimateShake()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Vector3[] sourceVertices = cachedMeshInfo[materialIndex].vertices;
            Vector3[] destinationVertices = textInfo.meshInfo[materialIndex].vertices;

            float shakeX = Random.Range(-amplitude, amplitude);
            float shakeY = Random.Range(-amplitude, amplitude);

            for (int j = 0; j < 4; j++)
            {
                destinationVertices[vertexIndex + j].x = sourceVertices[vertexIndex + j].x + shakeX;
                destinationVertices[vertexIndex + j].y = sourceVertices[vertexIndex + j].y + shakeY;
            }
        }

        ApplyMeshChanges();
    }

    void AnimateColorCycle()
    {
        for (int i = 0; i < textMeshPro.textInfo.characterCount; i++)
        {
            TMP_CharacterInfo c = textMeshPro.textInfo.characterInfo[i];

            if (!c.isVisible)
                continue;

            int materialIndex = c.materialReferenceIndex;
            int vertexIndex = c.vertexIndex;

            Color32[] vertexColors = textInfo.meshInfo[materialIndex].colors32;

            float hue = (Time.time * speed + i * frequency) % 1f;
            Color color = Color.HSVToRGB(hue, 1f, 1f);

            for (int j = 0; j < 4; j++)
            {
                vertexColors[vertexIndex + j] = color;
            }
        }

        ApplyColorChanges();
    }

    void ApplyMeshChanges()
    {
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
            textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }

    void ApplyColorChanges()
    {
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}