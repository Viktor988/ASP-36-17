using ApiNovine.Application;
using ApiNovine.Application.Commands;
using ApiNovine.Application.Commands.Comment;
using ApiNovine.Application.Commands.Picture;
using ApiNovine.Application.Commands.Post;
using ApiNovine.Application.Commands.Rate;
using ApiNovine.Application.Commands.Role;
using ApiNovine.Application.Queries;
using ApiNovine.Application.Queries.Comment;
using ApiNovine.Application.Queries.Picture;
using ApiNovine.Application.Queries.Rate;
using ApiNovine.Application.Queries.Role;
using ApiNovine.Implementation.Commands;
using ApiNovine.Implementation.Commands.Comment;
using ApiNovine.Implementation.Commands.Picture;
using ApiNovine.Implementation.Commands.Post;
using ApiNovine.Implementation.Commands.Rate;
using ApiNovine.Implementation.Commands.Role;
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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovineApi.Core
{
	public static class ContainerExtension
	{
		public static void AddUseCases(this IServiceCollection services)
		{
			services.AddTransient<IGetPostsQuery, EfGetPostsQuery>();
			services.AddTransient<IGetPostQuery, EfGetPostQuery>();
			services.AddTransient<ICreatePostCommand, EfCreatePostCommand>();
			services.AddTransient<IDeletePostCommand, EfDeletePostCommand>();
			services.AddTransient<IUpdatePostCommand, EfUpdatePostCommand>();

			services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogQuery>();


			services.AddTransient<ICreateRateCommand, EfCreateRateCommand>();
			services.AddTransient<IGetRatesQuery, EfGetRatesQuery>();
			services.AddTransient<IDeleteRateCommand, EfDeleteRateCommand>();
			services.AddTransient<IUpdateRateCommand, EfUpdateRateCommand>();
			services.AddTransient<IGetRateQuery, EfGetRateQuery>();

			services.AddTransient<IGetPictureQuery, EfGetPictureQuery>();
			services.AddTransient<IDeletePictureCommand, EfDeletePictureCommand>();

			services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();
			services.AddTransient<ICreateRoleCommand, EfCreateRoleCommand>();
			services.AddTransient<IGetRolesQuery, EfGetRolesQuery>();
			services.AddTransient<IUpdateRoleCommand, EfUpdateRoleCommand>();
			services.AddTransient<IGetRoleQuery, EfGetRoleQuery>();

			services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
			services.AddTransient<IGetUserQuery, EfGetUserQuery>();
			services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
			services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
			services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();

			services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
			services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
			services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();
			services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
			services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();

			services.AddTransient<ICreateTagCommand, EfCreateTagCommand>();
			services.AddTransient<IGetTagsQuery, EfGetTagsQuery>();
			services.AddTransient<IGetTagQuery, EfGetTagQuery>();
			services.AddTransient<IUpdateTagCommand, EfUpdateTagCommand>();
			services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();

			services.AddTransient<IGetCommentsQuery, EfGetCommentsQuery>();
			services.AddTransient<ICreateCommentCommand, EfcreateCommentCommand>();
			services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();
			services.AddTransient<IUpdateCommentCommand, EfUpdateCommentCommand>();
			services.AddTransient<IGetCommentQuery, EfGetCommentQuery>();
			services.AddTransient<UseCaseExecutor>();
			services.AddTransient<CreateCategoryValidator>();
			services.AddTransient<UpdateCategoryValidator>();
			services.AddTransient<CreatePostValidator>();
			services.AddTransient<UpdatePostValidator>();
			services.AddTransient<InsertUserValidation>();
			services.AddTransient<DeleteCategoryValidator>();
			services.AddTransient<DeletePictureValidator>();
			services.AddTransient<UpdateUserValidation>();
			services.AddTransient<UpdateTagValidator>();
			services.AddTransient<UpdateCommentValidator>();
			services.AddTransient<CreateCommentValidator>();
			services.AddTransient<CreateRateValidator>();
			services.AddTransient<CreateRoleValidator>();
			services.AddTransient<UpdateRoleValidator>();
			services.AddTransient<DeleteRoleValidator>();
			services.AddTransient<UpdateRateValidator>();
			services.AddTransient<CreateTagValidator>();
			services.AddTransient<RegisterUserValidator>();

		}

		public static void AddApplicationActor(this IServiceCollection services)
		{
			services.AddTransient<IApplicationActor>(x =>
			{
				var accessor = x.GetService<IHttpContextAccessor>();


				var user = accessor.HttpContext.User;

				if (user.FindFirst("ActorData") == null)
				{
					return new Anonymous();
				}

				var actorString = user.FindFirst("ActorData").Value;

				var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

				return actor;

			});
		}

		public static void AddJwt(this IServiceCollection services)
		{
			services.AddAuthentication(options =>
			{
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = "asp_api",
					ValidateIssuer = true,
					ValidAudience = "Any",
					ValidateAudience = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
			});
		}
	}
}
