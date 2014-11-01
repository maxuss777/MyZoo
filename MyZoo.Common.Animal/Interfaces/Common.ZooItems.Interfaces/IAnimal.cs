﻿namespace MyZoo.Common.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        string Kind { get; }
        string Food { get; }
        int CageId { get; }

        string[] ShowDetails();
    }
}