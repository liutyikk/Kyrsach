namespace Kyrsach.Command
{
    public class CommandLineInterface
    {
        private readonly Dictionary<string, ICommand> _commands;

        public CommandLineInterface()
        {
            _commands = new Dictionary<string, ICommand>();
        }

        public void RegisterCommand(string name, ICommand command)
        {
            _commands[name] = command;
        }

        public void ExecuteCommand(string name)
        {
            if (_commands.TryGetValue(name, out var command))
            {
                command.Execute();
            }
            else
            {
                Console.WriteLine("Command not found.");
            }
        }

        public ICommand GetCommand(string name)
        {
            _commands.TryGetValue(name, out var command);
            return command;
        }
    }
}