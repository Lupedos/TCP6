using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BracoPaciente : MonoBehaviour
{
    [SerializeField] private Image machucado;
    [SerializeField] private GameObject pontinhosParent;
    private List<Image> pontinhos;


    private void Start()
    {
        machucado.DOFade(0, 0);
        pontinhos = pontinhosParent.GetComponentsInChildren<Image>().ToList();

    }

    public void AtivarPontinho()
    {
        if (pontinhos.Count == 0) return;
        int randomIndex = Random.Range(0, pontinhos.Count - 1);
        pontinhos[randomIndex].DOFade(1,1);
        pontinhos.Remove(pontinhos[randomIndex]);

    }



}
