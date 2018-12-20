using System.Collections;

public interface IDestroyable
{
    void UpdateDestroyState(float currentHealthInPercents);
    void Destroy();
    void DestroyWithDelay();
    bool IsDestroyed();
}
