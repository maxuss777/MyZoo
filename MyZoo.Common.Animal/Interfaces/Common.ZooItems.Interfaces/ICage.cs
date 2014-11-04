

namespace MyZoo.Common.Interfaces
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