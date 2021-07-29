using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        //List<OperationClaim> GetClaims(User user);
        //void Add(User user);
        //User GetByMail(string email);


        //void Update(User user);
        //void Delete(User user);
        //List<User> GetById(int id);
        //IDataResult<List<User>> GetAll();
        //IResult EditProfile(UserForUpdateDto user);

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IResult EditProfile(UserForUpdateDto user);


    }
}
