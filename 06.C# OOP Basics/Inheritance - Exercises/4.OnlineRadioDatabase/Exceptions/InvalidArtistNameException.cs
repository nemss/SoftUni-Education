using System.Runtime.InteropServices;

namespace _4.OnlineRadioDatabase
{
    public class InvalidArtistNameException : InvalidSongException
    {
        private const string Message = "Artist name should be between 3 and 20 symbols.";
                              
        public InvalidArtistNameException()
            : base(Message)
        {
            
        }

        public InvalidArtistNameException(string message) 
            : base(message)
        {
        }
    }
}
