﻿using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Mİcrosoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreMOdule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();

            // Sistem Redis'e geçerse MemoryCacheManager kısmını Redis ile değiştirmek
            // tüm sistemin redis'e geçmesini sağlayacaktır.
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
