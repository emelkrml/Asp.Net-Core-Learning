﻿using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Business.Concrete.Constants;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }


        public override void Intercept(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
