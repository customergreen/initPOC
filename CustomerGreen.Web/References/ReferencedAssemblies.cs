using System.Reflection;

namespace CustomerGreen.Web.References
{
    public static class ReferencedAssemblies
    {
        public static Assembly Services
        {
            get { return Assembly.Load("CustomerGreen.Services"); }
        }

        public static Assembly Repositories
        {
            get { return Assembly.Load("CustomerGreen.Data"); }
        }

        public static Assembly Dto
        {
            get
            {
                return Assembly.Load("CustomerGreen.Dto");
            }
        }

        public static Assembly Domain
        {
            get
            {
                return Assembly.Load("CustomerGreen.Core");
            }
        }
    }
}
