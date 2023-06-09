﻿namespace ArchProject.Commands;

public interface ICommand
{
    void Execute();
    void Undo();

    string Description { get; }
}