namespace ArchProject.Commands;

public class MacroCommand : ICommand
{
    private readonly List<ICommand> _commands;
    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }

    public void Undo()
    {
        foreach (var command in _commands)
        {
            command.Undo();
        }
    }

    public string Description { get; set; }
    
    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }
}