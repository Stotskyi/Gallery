namespace GalleryAPI.Exceptions;

public class SignUpFailedException : Exception
{
    public SignUpFailedException(string error) :
        base(error)
    {
        
    }
}