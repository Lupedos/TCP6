using DG.Tweening;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ClickablePointView : MonoBehaviour
{
    [SerializeField] private Sprite corretSprite;
    [SerializeField] private Sprite wrongSprite;

    [Space(20)]
    [SerializeField] private AudioClip corretClip;
    [SerializeField] private AudioClip wrongClip;

    [Space(20)]
    [SerializeField] private ViewAnimationProps showAnimProps;
    private Image image;
    private ClickablePoint clickablePoint;
    private AudioSource audioSource;


    private void Awake()
    {
        image = GetComponent<Image>();
        clickablePoint = GetComponent<ClickablePoint>();    
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void Start()
    {
        image.sprite = default;
        image.CrossFadeAlpha(0.1f, 0, false);
        clickablePoint.AttemptResult += ShowResult;

    }

    private void OnDestroy()
    {
        clickablePoint.AttemptResult -= ShowResult;

    }

    private void ShowResult(ClickablePoint point)
    {
        if(point.IsCorret)
        {
            image.sprite = corretSprite;
            SoundEffectPlayerManager.Instance.PlayCickableSfx(corretClip);

        } else
        {
            image.sprite = wrongSprite;
            SoundEffectPlayerManager.Instance.PlayCickableSfx(wrongClip);
        }

        //animation of click point
        image.CrossFadeAlpha(1, 0, false);
        image.sprite = (point.IsCorret) ? corretSprite : wrongSprite;
        transform.localScale = Vector3.zero;
        transform.DOScale(1, showAnimProps.duration).SetEase(showAnimProps.interpolationMode);

    }



}
