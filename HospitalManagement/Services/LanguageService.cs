﻿using Microsoft.Extensions.Localization;
using System.Reflection;


namespace HospitalManagement.Services
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create(nameof(SharedResource), assemblyName.Name);

        }

        public LocalizedString Getkey(string key)
        {

            return _localizer[key];
        }
    }

    public class SharedResource
    {

    }
}
