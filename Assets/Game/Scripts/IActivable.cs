using System;

namespace Game
{
    public interface IActivable
    {
        public bool IsActive { get; }
        public event Action<bool> Activate;
        public void SetActive(bool active);

    }
}
