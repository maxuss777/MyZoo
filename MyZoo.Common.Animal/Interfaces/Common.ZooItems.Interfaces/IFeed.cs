namespace MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces
{
    public interface IFeed
    {
        string ForWhom { get; }
        string Type { get; }
        int Gross { get; }
    }
}
