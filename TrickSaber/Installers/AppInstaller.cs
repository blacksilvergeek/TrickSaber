﻿using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using HMUI;
using SiraUtil;
using TrickSaber.Configuration;
using UnityEngine;
using Zenject;
using Logger = IPA.Logging.Logger;

namespace TrickSaber.Installers
{
    class AppInstaller : Installer
    {
        private readonly PluginConfig _config;
        private readonly Logger _logger;

        private AppInstaller(PluginConfig config, Logger logger)
        {
            _config = config;
            _logger = logger;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindLoggerAsSiraLogger(_logger);
            Container.BindInterfacesAndSelfTo<TrickSaberPlugin>().AsSingle();
        }
    }
}
