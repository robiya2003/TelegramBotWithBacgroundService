namespace TelegramBotWithBacgroundService.RegistratsiyaUserService
{
    public interface  IUserService
    {
        public Task Add(UserModel user);
        public Task<List<UserModel>> GetAllUsers();
    }
}
