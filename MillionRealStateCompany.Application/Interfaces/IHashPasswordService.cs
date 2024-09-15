namespace MillionRealStateCompany.Application.Interfaces
{
    public interface IHashPasswordService
    {
        string GenerateHash(string source);

        bool ValidateHash(string input, string hash);
    }
}
