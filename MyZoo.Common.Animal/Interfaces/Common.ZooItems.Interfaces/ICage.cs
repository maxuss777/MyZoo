namespace MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces
{
    public interface ICage
    {
        string Type { get; }
        int Height { get; }
        int Width { get; }
        int Length { get; }
        int Id { get; }

        string[] ShowDetails();
    }
}