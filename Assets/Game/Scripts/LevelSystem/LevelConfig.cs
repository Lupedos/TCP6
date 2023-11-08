using System;
using UnityEngine;

[Serializable]
public class LevelConfig 
{
    [SerializeField] private bool pacienteContamindo;

    [Header("Se TRUE, habilita o objeto na mesa.")]
    [SerializeField] private bool seringaObjectOn;
    [SerializeField] private bool raioXObjectOn;
    [SerializeField] private bool microscopioObjectOn;

    [Header("Configurações do minigame da seringa.")]
    [SerializeField] private bool machudoSeringaGrande;



    public bool SeringaOn { get => seringaObjectOn;  }
    public bool RaioXOn { get => raioXObjectOn;}
    public bool MicroscopioOn { get => microscopioObjectOn;  }
    public bool PacienteContamindo { get => pacienteContamindo; }
    public bool MachudoSeringaGrande { get => machudoSeringaGrande; }
}
