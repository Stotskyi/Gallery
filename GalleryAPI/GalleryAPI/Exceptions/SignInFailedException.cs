namespace GalleryAPI.Exceptions;

public class SignInFailedException(string error) : Exception(error);