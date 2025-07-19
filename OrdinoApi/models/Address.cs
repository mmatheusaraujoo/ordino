namespace OrdinoApi.Models;

public class Address
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }

    public Client Client { get; set; } = new();
}