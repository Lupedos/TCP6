
using System;

public interface IObjective {
    public bool Complete {get;  set;}
    public  event Action OnComplete;

}
