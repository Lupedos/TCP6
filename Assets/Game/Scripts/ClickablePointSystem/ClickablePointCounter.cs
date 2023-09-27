using TMPro;
using UnityEngine;


public class ClickablePointCounter : MonoBehaviour
{
    [SerializeField] private ClickablePointController clickablePointController;
    [SerializeField] private TMP_Text text_CorrectCounter;
    [SerializeField] private TMP_Text text_WrongCounter;



    private void Start()
    {
        clickablePointController.CorrectClick += SetCorretCount;
        clickablePointController.WrongClick += SetWrongCount;

    }

    private void OnDestroy()
    {
        clickablePointController.CorrectClick -= SetCorretCount;
        clickablePointController.WrongClick -= SetWrongCount;

    }

    public void SetCorretCount(int corretCount)
    {
        text_CorrectCounter.SetText(corretCount.ToString());
    }

    public void SetWrongCount(int wrongCount)
    {
        text_WrongCounter.SetText(wrongCount.ToString());
    }


}
