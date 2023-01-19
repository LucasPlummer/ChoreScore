namespace ChoreScore.Models;


public class Chore
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public string Location { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
}
