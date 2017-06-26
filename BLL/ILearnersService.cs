namespace BLL
{
    public interface ILearnersService
    {
        void AddCard(string key, string value, string learnerId);
        int CountCards(string learnerId);
        string PrintAll(string learnerId);
    }
}