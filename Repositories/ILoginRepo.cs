namespace Academy.Repos
{
    public interface ILoginRepo
    {
        Task<bool> ValidateUser(string usernameOrEmail, string password);
    }
}
