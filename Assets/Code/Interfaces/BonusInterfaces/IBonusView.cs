public interface IBonusView 
{
    bool collected { get; }

    void OnCollected();
}
