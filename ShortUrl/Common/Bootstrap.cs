﻿using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ShortUrl.Core.Patterns;
using ShortUrl.DataAccessLayer;
using ShortUrl.DataAccessLayer.Contacts;
using ShortUrl.Repositories;
using ShortUrl.Repositories.Contracts;
using ShortUrl.Services;
using ShortUrl.Services.Contracts;

namespace ShortUrl.Common
{
	public static class Bootstrap
	{
		public static void Run(HttpConfiguration config)
		{
			ConfigureDependencyInjection(config);
		}

		private static void ConfigureDependencyInjection(HttpConfiguration config)
		{
			var builder = new ContainerBuilder();

			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
			builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
			builder.RegisterType<UrlRepository>().As<IUrlRepository>();
			builder.RegisterType<SimplePatternGenerator>().As<IPatternGenerator>();
			builder.RegisterType<UrlService>().As<IUrlService>();

			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}