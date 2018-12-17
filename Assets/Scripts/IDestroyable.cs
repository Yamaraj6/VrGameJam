using System.Collections;

public interface IDestroyable
{
    void SetDestroyState(float currentHealthInPercents);
    void Destroy();
    bool IsDestroyed();
}
