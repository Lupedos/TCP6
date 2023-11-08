using TMPro;
using UnityEngine;


public class ClickablePointCounter : MonoBehaviour
{
    [SerializeField] private ClickablePointController clickablePointController;
    [SerializeField] private TMP_Text text_CorrectCounter;
    [SerializeField] private TMP_Text text_WrongCounter;



    private void Start()
    {
        clickablePointController.OnClick += SetCurrentMarkedCount;

    }

    private void OnDestroy()
    {
        clickablePointController.OnClick -= SetCurrentMarkedCount;
    }

    public void SetCurrentMarkedCount(int markedCount)
    {
        text_CorrectCounter.SetText(markedCount.ToString());
    }

    public void SetWrongCount(int wrongCount)
    {
        text_WrongCounter.SetText(wrongCount.ToString());
    }




}
