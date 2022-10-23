using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AboutManager>().As<IAboutService>();
            builder.RegisterType<EfAboutDal>().As<IAboutDal>();

            builder.RegisterType<BlogManager>().As<IBlogService>();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>();

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<MessageFkManager>().As<IMessageFkService>();
            builder.RegisterType<EfMessageFkDal>().As<IMessageFkDal>();

            builder.RegisterType<NewsletterManager>().As<INewsletterService>();
            builder.RegisterType<EfNewsletterDal>().As<INewsletterDal>();

            builder.RegisterType<NotificationManager>().As<INotificationService>();
            builder.RegisterType<EfNotificationDal>().As<INotificationDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<WriterManager>().As<IWriterService>();
            builder.RegisterType<EfWriterDal>().As<IWriterDal>();
        }
    }
}