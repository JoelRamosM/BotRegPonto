using Ninject.MockingKernel.NSubstitute;

namespace BotPonto.Tests.Commom
{
    public abstract class TesteBase
    {
        protected NSubstituteMockingKernel kernel;

        protected TesteBase()
        {
            kernel = new NSubstituteMockingKernel();
        }
    }
}
