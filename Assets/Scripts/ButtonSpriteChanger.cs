using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSpriteChanger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public Sprite clickSprite;
    public float clickSpriteDuration = 0.5f; // Duration to show the click sprite
    public AudioClip clickSound; // Audio clip to play on click
    public Material ImageFadeMat;

    private Image buttonImage;
    private AudioSource audioSource;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        buttonImage.sprite = defaultSprite;



        // Add AudioSource component if not already present
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonImage.sprite = clickSprite;
        StartCoroutine(ColorFadeTimer(0f, 1f, 0.3f));
        StartCoroutine(RevertToDefaultSpriteAfterDelay());

        // Play click sound
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private IEnumerator RevertToDefaultSpriteAfterDelay()
    {
        yield return new WaitForSeconds(clickSpriteDuration);
        buttonImage.sprite = defaultSprite;
        ImageFadeMat.SetFloat("_colorfade", 0f);
    }

    private IEnumerator ColorFadeTimer(float start, float end, float duration)
    {
        float elapsed = 0f;
        float currentValue = ImageFadeMat.GetFloat("_colorfade");
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            currentValue = Mathf.Lerp(start, end, t);
            ImageFadeMat.SetFloat("_colorfade", currentValue);
            yield return null;
        }

        ImageFadeMat.SetFloat("_colorfade", end);
    }
}
