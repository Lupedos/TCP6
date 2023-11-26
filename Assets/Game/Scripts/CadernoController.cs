using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CadernoController : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] private Button sintomasButton;
    [SerializeField] private Button riscosButton;
    [SerializeField] private Button examesButton;
    [Space(20)]
    [SerializeField] private Image sintomasCaderno;
    [SerializeField] private Image riscosCaderno;
    [SerializeField] private Image examesCaderno;

    private RectTransform sintomasTransform;
    private RectTransform riscosTransform;
    private RectTransform examesTransform;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>(); 
    }
    private void Start()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        sintomasButton.onClick.AddListener(MostrarSintomas);
        riscosButton.onClick.AddListener(MostrarRiscos);
        examesButton.onClick.AddListener(MostrarExames);

        configureButtonSize();

    }




    private void OnDestroy()
    {
        sintomasButton.onClick.RemoveListener(MostrarSintomas);
        riscosButton.onClick.RemoveListener(MostrarRiscos);
        examesButton.onClick.RemoveListener(MostrarExames);
    }

    private void SwitchCadernos(Image caderno)
    {
        sintomasCaderno.gameObject.SetActive(false);
        riscosCaderno.gameObject.SetActive(false);
        examesCaderno.gameObject.SetActive(false);
        caderno.gameObject.SetActive(true);
    }
    private void configureButtonSize()
    {
        sintomasTransform = sintomasButton.GetComponent<RectTransform>();
        riscosTransform = riscosButton.GetComponent<RectTransform>();
        examesTransform = examesButton.GetComponent<RectTransform>();

        sintomasTransform.sizeDelta = new Vector2(sintomasTransform.sizeDelta.x, 100);
        riscosTransform.sizeDelta = new Vector2(riscosTransform.sizeDelta.x, 100);
        examesTransform.sizeDelta = new Vector2(examesTransform.sizeDelta.x, 100);
    }

    private void SwitchButtonsScale(Button button)
    {
        sintomasButton.transform.localScale = Vector3.one;
        examesButton.transform.localScale = Vector3.one;
        riscosButton.transform.localScale = Vector3.one;
        button.transform.localScale = Vector3.one * 1.3f;
    }



    public void MostrarSintomas()
    {
        SwitchCadernos(sintomasCaderno);
        SwitchButtonsScale(sintomasButton);
        
    }
    public void MostrarRiscos()
    {
        SwitchCadernos(riscosCaderno);
        SwitchButtonsScale(riscosButton);

    }
    public void MostrarExames()
    {
        SwitchCadernos(examesCaderno);
        SwitchButtonsScale(examesButton);

    }




}
