namespace MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces
{
    public interface IFeed
    {
        string Type { get; }
        int Gross { get; }
        string ForWhom { get; }
        int Id { get; }

        string[] ShowDetails();
    }
}
