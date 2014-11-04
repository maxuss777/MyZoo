

namespace MyZoo.Common.Interfaces
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
