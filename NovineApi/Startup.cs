using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.Commands.Comment;
using ApiNovine.Application.Commands.Picture;
using ApiNovine.Application.Commands.Post;
using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.Commands.Role;
using ApiNovine.Application.Email;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Queries.Comment;
using ApiNovine.Application.Queries.Picture;
using ApiNovine.Application.Queries.Rate;
using ApiNovine.Application.Queries.Role;
using ApiNovine.DataAccess;
using ApiNovine.Implementation;
using ApiNovine.Implementation.Commands;
using ApiNovine.Implementation.Commands.Comment;
using ApiNovine.Implementation.Commands.Picture;
using ApiNovine.Implementation.Commands.Post;
using ApiNovine.Implementation.Commands.Rate;
using ApiNovine.Implementation.Commands.Role;
using ApiNovine.Implementation.Email;
using ApiNovine.Implementation.Logging;
using ApiNovine.Implementation.Queries;
using ApiNovine.Implementation.Queries.Comment;
using ApiNovine.Implementation.Queries.Picture;
using ApiNovine.Implementation.Queries.Rate;
using ApiNovine.Implementation.Queries.Role;
using ApiNovine.Implementation.Validators;
using ApiNovine.Implementation.Validators.Category;
using ApiNovine.Implementation.Validators.Comment;
using ApiNovine.Implementation.Validators.Picture;
using ApiNovine.Implementation.Validators.Post;
using ApiNovine.Implementation.Validators.Rate;
using ApiNovine.Implementation.Validators.Role;
using ApiNovine.Implementation.Validators.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using NovineApi.Core;

namespace NovineApi
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddTransient<ApiNovineContext>();
			services.AddTransient<JwtManager>();
			services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
			services.AddTransient<RegisterUserValidator>();
			services.AddTransient<IEmailSender,SMTPEmailSender>();

			
			services.AddUseCases();

			services.AddTransient<IUseCaseLogger, DataBaseUseCaseLogger>();
		
			services.AddHttpContextAccessor();
			services.AddApplicationActor();


			services.AddJwt();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Novine Api", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						  {
							Reference = new OpenApiReference
							  {
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							  },
							  Scheme = "oauth2",
							  Name = "Bearer",
							  In = ParameterLocation.Header,

							},
							new List<string>()
						  }
					});
			});



		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
			});
			app.UseRouting();
			app.UseMiddleware<GlobalExceptionHandler>();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
