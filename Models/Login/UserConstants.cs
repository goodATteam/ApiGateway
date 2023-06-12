namespace ApiGateway.Models.Login
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
            {
                new UserModel(){ Username="User1",Password="Pass1",Role="Admin"},
                new UserModel(){ Username="User2",Password="Pass2",Role="User"},
                new UserModel(){ Username="User3",Password="Pass3",Role="User"}
            };
    }
}