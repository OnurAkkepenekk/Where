using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        public IDataResult<UserForUserInformationsDto> GetByMailForUserInformations(string email)
        {
            var result=_userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<UserForUserInformationsDto>(Messages.UserNotFound);
            }
            var user = new UserForUserInformationsDto
            {
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
            return new SuccessDataResult<UserForUserInformationsDto>(user,Messages.BringUserInformation);

        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
