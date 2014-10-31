namespace MyZoo.Common.Animal.Interfaces.Common.ZooItems.Interfaces
{
    public interface ICage
    {
        int Height { get; }
        int Width { get; }
        int Length { get; }
        int WhomBelongs { get; }
        string[] ShowDetails();
    }
}