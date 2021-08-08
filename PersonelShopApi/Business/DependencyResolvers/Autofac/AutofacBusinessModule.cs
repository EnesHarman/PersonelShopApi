using Autofac;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities.Abstract;
using Business.Utilities.Jwt;
using Core.Utilities.Mail.Abstract;
using Core.Utilities.Mail.Concrete;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
            
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>();

            builder.RegisterType<EfPictureDal>().As<IPictureDal>();

            builder.RegisterType<MailManager>().As<IMailService>();

            builder.RegisterType<JwtParser>().As<IParser>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

        }
    }
}
