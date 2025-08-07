namespace StockWebApi.Models.Request.Define
{
    public enum CreateUserStatus
    { 
        Success,        //成功
        ExistUsers,     //已有使用者
        DataFail,       //資料錯誤
    }

    public enum UpdateUserStatus
    {
        Success,        //成功
        NotExistUsers,  //不存在使用者
        PasswordFail,   //密碼錯誤
        DataFail,       //資料錯誤
    }

    public enum UserPermissionType
    {
        None = 0,       //無權限
        User = 1,       //使用者
        Admin = 2,      //管理員
        SuperAdmin = 3, //超級管理員
    }
}
