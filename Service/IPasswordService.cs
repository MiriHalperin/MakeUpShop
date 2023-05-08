namespace Service
{
    public interface IPasswordService
    {
        Task<int> goodPassword(string pwd);
    }
}