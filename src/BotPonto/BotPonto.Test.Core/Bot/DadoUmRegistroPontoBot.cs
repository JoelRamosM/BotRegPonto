using BotPonto.Core.Bot;
using BotPonto.Core.Interface;
using BotPonto.Core.Interface.Services;
using BotPonto.CrossCuting.Exceptions;
using BotPonto.CrossCuting.Interfaces;
using BotPonto.Tests.Commom;
using Ninject;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Telegram.Bot.Types;

namespace BotPonto.Test.Core.Bot
{
    [TestFixture]
    public class DadoUmRegistroPontoBot : TesteBase
    {
        private RegistroPontoBot _sut;
        private string webHookAdress;
        private IBotApiService apiService;
        private IBotCommands botCommands;
        private string token;

        [SetUp]
        public void Setup()
        {
            kernel.Reset();
            kernel.Unbind<RegistroPontoBot>();
            token = "666";
            webHookAdress = "teste.com/webhook";
            kernel.Bind<RegistroPontoBot>().ToSelf()
                .WithConstructorArgument("token", token)
                .WithConstructorArgument("webHookUrl", webHookAdress);


            botCommands = kernel.Get<IBotCommands>();
            _sut = kernel.Get<RegistroPontoBot>();
            apiService = kernel.Get<IBotApiService>();
        }
        [Test]
        public void PossoRecuperarTokenApartirDoBot() => Assert.AreEqual(token, _sut.Token);

        [Test]
        public void NomeDoBotEhRegistroPontoBot() => Assert.AreEqual("RegistroPontoBot", _sut.Name);

        [Test]
        public void AoConfigurarWebHookKSetWebHookDeApiServiceEhChaemdo()
        {
            _sut.ConfigureWebHook();
            apiService.Received().SetWebHook(webHookAdress);
        }

        [Test]
        public void AoExecutarCommandoChamaRunDeBotCommand()
        {
            var comando = "/teste";
            var chatId = 666;
            var resultCommand = "Mensagem teste.";
            var commandService = Substitute.For<IBotCommand>();
            commandService.Run(Arg.Any<Update>()).Returns(resultCommand);
            var message = Substitute.For<ITelegramMessage>();
            message.ChatId.Returns(chatId);
            message.Comando.Returns(comando);
            botCommands[comando].Returns(commandService);
            _sut.RunCommand(message);
            commandService.Received().Run(Arg.Any<Update>());
            apiService.Received().EnviarMensagem(chatId, resultCommand);
        }

        [Test]
        public void AoExecutarComandoSeNãoExistirComandoChamaEnviarMensagemComNotificandoQueComandoNãoExiste()
        {
            var comando = "/teste";
            var chatId = 666;
            var expectedMessage = "Testando, comando não existe X(.";
            var message = Substitute.For<ITelegramMessage>();
            message.ChatId.Returns(chatId);
            message.Comando.Returns(comando);
            botCommands[comando].Throws(new ComandoInexistenteException(expectedMessage));
            _sut.RunCommand(message);
            apiService.Received().EnviarMensagem(chatId, expectedMessage);
        }

        [Test]
        public void AoExecutarComandoAsyncChamaRunAsyncDeBotCommandEChamaEnviarMensagemDeApiService()
        {
            var comando = "/teste";
            var chatId = 666;
            var commandService = Substitute.For<IBotCommand>();
            var message = Substitute.For<ITelegramMessage>();
            message.ChatId.Returns(chatId);
            message.Comando.Returns(comando);
            botCommands[comando].Returns(commandService);
            _sut.RunCommandAsync(message).Wait();
            commandService.Received().RunAsync(Arg.Any<Update>());
            apiService.Received().EnviarMensagem(chatId, Arg.Any<string>());

        }

        [Test]
        public void AoExecutarComandoAsyncSeNãoExistirComandoChamaEnviarMensagemComNotificandoQueComandoNãoExiste()
        {
            var comando = "/teste";
            var chatId = 666;
            var expectedMessage = "Testando, comando não existe X(.";
            var message = Substitute.For<ITelegramMessage>();
            message.ChatId.Returns(chatId);
            message.Comando.Returns(comando);
            botCommands[comando].Throws(new ComandoInexistenteException(expectedMessage));
            _sut.RunCommandAsync(message).Wait();
            apiService.Received().EnviarMensagem(chatId, expectedMessage);
        }
    }
}
