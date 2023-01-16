namespace ChoreScore.Repositories;



public class ChoresRepository
{

    private List<Chore> choreDb;

    public ChoresRepository()
    {
        this.choreDb = new List<Chore>(){
                new Chore(1, "Take out garbage", 2, "Outside"),
                new Chore(2, "Fold clothes", 3, "Room"),
                new Chore(3, "Do dishes", 3, "Kitchen"),
                new Chore(4, "Mow the lawn", 5, "Outside")
            };
    }

    internal Chore Create(Chore choreData)
    {
        choreData.Id = choreDb[choreDb.Count - 1].Id + 1;
        choreDb.Add(choreData);
        return choreData;
    }
    internal List<Chore> Get()
    {
        return choreDb;
    }

    internal string Remove(int id)
    {
        Chore choreToRemove = choreDb.Find(c => c.Id == id);
        bool result = choreDb.Remove(choreToRemove);
        if (result)
        {
            return $"{choreToRemove} was removed from db";
        }
        return "Chore does not exist??";
    }
}
