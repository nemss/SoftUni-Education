namespace PhotoShare.Client.Core
{
    using Commands;
    using System;
    using System.Linq;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string commandName = commandParameters[0];
            commandParameters = commandParameters.Skip(1).ToArray();
            string result = string.Empty;

            switch (commandName)
            {
                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Execute(commandParameters);
                    break;
                case "AddTown":
                    AddTownCommand addTown = new AddTownCommand();
                    result = addTown.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    ModifyUserCommand modifyUser = new ModifyUserCommand();
                    result = modifyUser.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand();
                    result = deleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    AddTagCommand addTag = new AddTagCommand();
                    result = addTag.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    CreateAlbumCommand createAlbum = new CreateAlbumCommand();
                    result = createAlbum.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    AddTagToCommand addTagTo = new AddTagToCommand();
                    result = addTagTo.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    MakeFriendsCommand makeFriend = new MakeFriendsCommand();
                    result = makeFriend.Execute(commandParameters);
                    break;
                case "ListFriends":
                    PrintFriendsListCommand listFriends = new PrintFriendsListCommand();
                    result = listFriends.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    UploadPictureCommand uploadPicture = new UploadPictureCommand();
                    result = uploadPicture.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    ShareAlbumCommand shareAlbum = new ShareAlbumCommand();
                    result = shareAlbum.Execute(commandParameters);
                    break;
                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(commandParameters);
                    break;
                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute();
                    break;
                default:
                    Console.WriteLine($"Command {commandName} not valid!");
                    break;           
            }

            return result;
        }
    }
}
