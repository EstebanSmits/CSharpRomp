using System;
using System.Collections.Generic;
using CSharpRomp.Entities;

namespace CSharpRomp.Repository.Interfaces
{
    public interface IAppLoginRepository
    {
        bool AddAppLogin(AppLogin applogin);
        bool DeleteAppLogin(int id);
        AppLogin GetAppLogin();
        IEnumerable<AppLogin> GetAllAppLogins();
    }
}
