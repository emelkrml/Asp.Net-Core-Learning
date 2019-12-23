using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(USerForRegisterDto userForRegesterDto, string password);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExists(string Email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }

}
