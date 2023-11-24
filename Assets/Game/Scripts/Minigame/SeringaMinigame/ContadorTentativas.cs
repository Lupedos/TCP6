using System;
using TMPro;
using UnityEngine;

[Serializable]
public class ContadorTentativas
{
    [SerializeField] private TMP_Text text_tentativas;
    public int Tentativas { get; private set; } = 0;
    public void IncreaseTentativas()
    {
        Tentativas++;
        text_tentativas.SetText(Tentativas.ToString());
    }



}
