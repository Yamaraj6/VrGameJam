public interface IHealth
{
    float GetMaxHealth();
    float GetCurrentHealth();
    float GetPercentageCurrentHealth();
    void AddHealth(float value);
}