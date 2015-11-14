namespace Domain.Commands
{
    public class CreatePersonCommand : ICommand
    {
        public CreatePersonCommand(string Name,
            string Email)
        {
            this.Name = Name;
            this.Email = Email;
        }

        public string Name { get; private set; }

        public string Email { get; private set; }
    }
}
