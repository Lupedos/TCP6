using DG.Tweening;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ClickablePointView : MonoBehaviour
{
    [SerializeField] private AudioClip inMarkedClip;
    [SerializeField] private AudioClip outMarkedClip;

    [Space(20)]
    [SerializeField] private ViewAnimationProps showAnimProps;
    private ClickablePoint clickablePoint;

    private Transform childMarkup => transform.GetChild(0);

    private void Awake()
    {
        clickablePoint = GetComponent<ClickablePoint>();
    }

    private void Start()
    {
        childMarkup.DOScale(0, 0);
        //image.sprite = default;
        //image.CrossFadeAlpha(0.1f, 0, false);
        clickablePoint.AttemptResult += ShowResult;

    }

    private void OnDestroy()
    {
        clickablePoint.AttemptResult -= ShowResult;

    }


    private void ShowResult(ClickablePoint point)
    {

        if (point.marked)
        {
            SoundEffectPlayerManager.Instance.PlaySfx(inMarkedClip);

            childMarkup.localScale = Vector3.zero;
            childMarkup.DOScale(1, showAnimProps.duration).SetEase(showAnimProps.interpolationMode);
        }
        else
        {
            SoundEffectPlayerManager.Instance.PlaySfx(outMarkedClip);

            childMarkup.DOScale(0, showAnimProps.duration).SetEase(showAnimProps.interpolationMode);
        }


    }



}











//[RequireComponent(typeof(Image))]
//public class ClickablePointView : MonoBehaviour
//{
//    [SerializeField] private Sprite corretSprite;
//    [SerializeField] private Sprite wrongSprite;

//    [Space(20)]
//    [SerializeField] private AudioClip corretClip;
//    [SerializeField] private AudioClip wrongClip;

//    [Space(20)]
//    [SerializeField] private ViewAnimationProps showAnimProps;
//    private Image image;
//    private ClickablePoint clickablePoint;
//    private AudioSource audioSource;


//    private void Awake()
//    {
//        image = GetComponent<Image>();
//        clickablePoint = GetComponent<ClickablePoint>();    
//        audioSource = GetComponentInParent<AudioSource>();
//    }

//    private void Start()
//    {
//        //image.sprite = default;
//        //image.CrossFadeAlpha(0.1f, 0, false);
//        clickablePoint.AttemptResult += ShowResult;

//    }

//    private void OnDestroy()
//    {
//        clickablePoint.AttemptResult -= ShowResult;

//    }

//    private void ShowResult(ClickablePoint point)
//    {
//        if(point.IsCorret)
//        {
//            image.sprite = corretSprite;
//            SoundEffectPlayerManager.Instance.PlayCickableSfx(corretClip);

//        } else
//        {
//            image.sprite = wrongSprite;
//            SoundEffectPlayerManager.Instance.PlayCickableSfx(wrongClip);
//        }

//        //animation of click point
//        image.CrossFadeAlpha(1, 0, false);
//        image.sprite = (point.IsCorret) ? corretSprite : wrongSprite;
//        transform.localScale = Vector3.zero;
//        transform.DOScale(1, showAnimProps.duration).SetEase(showAnimProps.interpolationMode);

//    }



//}
