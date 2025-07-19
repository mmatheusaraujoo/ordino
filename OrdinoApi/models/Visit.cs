namespace OrdinoApi.Models;

public class Visit
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime VisitDate { get; set; } = DateTime.UtcNow;
    public string Notes { get; set; } = string.Empty;

    public Client Client { get; } = new ();
}
