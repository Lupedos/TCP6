using System.Collections;
using UnityEngine;

public class SeringaDirectionState : State
{
    [SerializeField] private SeringaMinigameController seringaController;
    [SerializeField] private float seringaMovementScale = 1f;
    [SerializeField] private float xOffset = 0.5f;
    private Vector3 seringaInitPos;
    private SeringaForceState forceState;
    [SerializeField] private AudioClip correctClickClip;
    [SerializeField] private AudioClip wrongClickClip;


    //TODO: para substituir o número 0.5f nas equações la embaixo.
    //na real, esses detalhes nem deveria estar aqui
    private float scroolbarMiddlePoint;

    public override void StateStart()
    {

        seringaController.SetMessage("Posição.");
        scroolbarMiddlePoint = seringaController.PrecisionClick.Scrollbar.size/2;
        seringaController.PrecisionClick.Scrollbar.onValueChanged.AddListener(OnScrollbarChange);
        seringaController.PrecisionClick.IsClickOnRange += IsClickOnRange;
        seringaController.PrecisionClick.SetActive(true);
        seringaController.PrecisionClick.SetEasyConfig();

    }

    public override void StateUpdate()
    {
        
    }

    public override void StateExit()
    {
        seringaController.PrecisionClick.Scrollbar.onValueChanged.RemoveListener(OnScrollbarChange);
        seringaController.PrecisionClick.IsClickOnRange -= IsClickOnRange;

    }


    private void Start()
    { 
        seringaInitPos = seringaController.SeringaObject.position;
        forceState = GetComponent<SeringaForceState>();
    }

    private void OnScrollbarChange(float arg0)
    {
        seringaController.SeringaObject.position = seringaInitPos + seringaMovementScale * Vector3.right * (arg0 - 0.5f) +Vector3.right*xOffset;
    }

    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(seringaController.SeringaObject.transform.position,seringaController.SeringaObject.transform.position+ seringaController.SeringaObject.transform.rotation*Vector3.up*10);
        if(seringaInitPos == Vector3.zero)
            Gizmos.DrawLine(
                
                seringaController.SeringaObject.position - seringaMovementScale * Vector3.right * (-0.5f) + Vector3.right * xOffset, 
                seringaController.SeringaObject.position + seringaMovementScale * Vector3.right * (-0.5f) + Vector3.right * xOffset);
        else
            Gizmos.DrawLine(
                seringaInitPos - seringaMovementScale * Vector3.right * (-0.5f) + Vector3.right * xOffset,
                seringaInitPos + seringaMovementScale * Vector3.right * (-0.5f) + Vector3.right * xOffset);
    }


    private void IsClickOnRange(bool value)
    {
        //MANDOU PARAR O MINIGAME E ACERTOU BUNITO
        if(value) 
        {
            StartCoroutine(CorrectClickAnim());
        }
        else 
        {
            StartCoroutine(WrongClickAnim());
        }
    }

    private Vector3 ForwardDir =>seringaController.SeringaObject.transform.position+seringaController.SeringaObject.transform.rotation*Vector3.up*0.1f;

    private IEnumerator CorrectClickAnim()
    {
        SoundEffectPlayerManager.Instance.PlaySfx(correctClickClip);

        seringaController.PrecisionClick.Scrollbar.onValueChanged.RemoveListener(OnScrollbarChange);
        seringaController.PrecisionClick.SetActive(false);
        // seringaController.SeringaObject.transform.DOMove(
        //     ForwardDir*downMoveScale,1
        //     ).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(1);
        stateController.SetState(forceState);

    }

    private IEnumerator WrongClickAnim() 
    {
        SoundEffectPlayerManager.Instance.PlaySfx(wrongClickClip);
        seringaController.PrecisionClick.SetActive(false);
        seringaController.PrecisionClick.Scrollbar.onValueChanged.RemoveListener(OnScrollbarChange);
        yield return new WaitForSeconds(1);
        seringaController.PrecisionClick.SetActive(true);
        seringaController.PrecisionClick.Scrollbar.onValueChanged.AddListener(OnScrollbarChange);



    }


}
