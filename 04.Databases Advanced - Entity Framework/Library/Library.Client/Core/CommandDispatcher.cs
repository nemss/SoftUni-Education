namespace Library.Client.Core
{
    using Commands;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ', '\t', '\'' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName)
            {
                case "help":
                    HelpCommand help = new HelpCommand();
                    result = help.Execute(inputArgs);
                    break;
                case "ExportToJson":
                    ExportToJsonCommand exportToJson = new ExportToJsonCommand();
                    result = exportToJson.Execute(inputArgs);
                    break;
                case "ChangeRole":
                    ChangeRoleCommand changeRole = new ChangeRoleCommand();
                    result = changeRole.Execute(inputArgs);
                    break;
                case "clear":
                    ClearCommand clear = new ClearCommand();
                    result = clear.Execute(inputArgs);
                    break;
                case "ShowAllUsers":
                    ShowAllUserCommand showAllUsers = new ShowAllUserCommand();
                    result = showAllUsers.Execute(inputArgs);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand();
                    result = addTown.Execute(inputArgs);
                    break;
                case "ModifyUser":
                    ModifyUserCommand modifyUser = new ModifyUserCommand();
                    result = modifyUser.Execute(inputArgs);
                    break;
                case "AddBook":
                    AddBookCommand addBook = new AddBookCommand();
                    result = addBook.Execute(inputArgs);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand();
                    result = deleteUser.Execute(inputArgs);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute(inputArgs);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(inputArgs);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}

