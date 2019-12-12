using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MVC_JSTC_DAL;
using MVC_JSTC_Repository.Repositories;
using System.Data.Entity.Core.Objects.DataClasses;

namespace MVC_JSTC_Repository.Repository
{
    //Interface for User-specific Methods
    public interface IUserRepository<T> : IRepository<tblUser, int>
    {
    }

    //Class contains User-Specific Methods
    public class UserRepository<T> : GenericRepository<tblUser>, IUserRepository<T>
    {
        public UserRepository(JusticeEntities _context) : base(_context)
        {
            this._context = _context;
        }
        /* 
         * ValidateLogin(user)
         * This method is used in HomeController Post-Index to get user's login credentials
         */
        public string ValidateLogin(string username, string password)
        {
            var returnStr = "";
            //Queries for Users with matchin username or email (whichever was given)
            var res_Name = _context.tblUsers.Where(u =>
                u.User_Username == username
                || u.User_Email == password)
                .FirstOrDefault();

            //If the username/Email Exists, continue to checking password match
            if (res_Name != null)
            {
                var resPass = _context.tblUsers.Where(u =>
                    (u.User_Username == username
                    || u.User_Email == username)
                    & u.User_Password == password)
                    .FirstOrDefault();

                //Password matches with username/email --> LOGIN
                if (resPass != null)
                {
                    returnStr = "success";
                    return returnStr;
                }

                //Password does not match --> RETURN TO INDEX
                else
                {
                    returnStr += "password";
                    return returnStr;
                }
            }

            //Username or Email DNE --> RETURN TO INDEX
            else
            {
                returnStr += "name";
                return returnStr;
            }
        }

        /****************** CREATE NEW USER METHOD  ******************/
        public string CreateNewUser(string username, string email, string password)
        {
            var returnStr = "";

            //check if email has not been taken
            var res_email = _context.tblUsers.Where(u => u.User_Email == email)
                .FirstOrDefault();
            if (res_email == null){
                returnStr += "email";
            }

            //check if username has not been taken
            var res_name = _context.tblUsers.Where(u => u.User_Username == username)
                        .FirstOrDefault();
            if (res_name == null){
                returnStr += "name";
            }

            if (returnStr == ""){
                _context.tblUsers.Add(new tblUser
                {
                    User_Email = email,
                    User_Username = username,
                    User_Password = password,
                    User_UserType = "customer",
                    User_Image = "url"
                });
                _context.SaveChanges();
                returnStr = "success";
            }
            return returnStr;
        }
    }
}