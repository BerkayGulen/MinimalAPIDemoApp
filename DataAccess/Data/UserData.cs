﻿using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers()
        {
            return _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });
        }

        public async Task<UserModel?> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id });

            return results.FirstOrDefault();
        }

        public async Task InsertUser(UserModel user)
        {
            await _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });
        }

        public async Task UpdateUser(UserModel user)
        {
            await _db.SaveData("dbo.spUser_Update", user);
        }

        public async Task DeleteUser(int id)
        {
            await _db.SaveData("dbo.spUser_Delete", new { Id = id });
        }

    }
}
