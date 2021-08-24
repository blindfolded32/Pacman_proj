public interface IBonusView 
{

    delegate void GotBonus(bool status);
    event GotBonus bonusPickedUp;

}
