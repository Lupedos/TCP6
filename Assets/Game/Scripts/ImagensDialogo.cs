using System;
using UnityEngine;

[Serializable]
public class ImagensDialogo
{
    [SerializeField] private int index;
    [SerializeField] private Sprite sprite;

    public int Index { get => index;  }
    public Sprite Sprite { get => sprite;  }
}


