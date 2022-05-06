using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using Microsoft.Extensions.Logging;
using Moq;
using Serilog;
using Serilog.AspNetCore;
using Serilog.Events;
using Serilog.Sinks.InMemory;
using Serilog.Sinks.InMemory.Assertions;
using Xunit;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTestsSerilog
    {
        public LoggingTestsSerilog()
        {
            /*Log.Logger = new LoggerConfiguration().WriteTo.File("C:\\DemoLogs\\log.txt",
                    rollingInterval: RollingInterval.Hour, 
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                    rollOnFileSizeLimit: true,
                    fileSizeLimitBytes: 20_971_520)
                .MinimumLevel.Information().CreateLogger();*/
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.InMemory()
                .CreateLogger();
        }

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());

            var microsoftLogger = new SerilogLoggerFactory(Log.Logger)
                .CreateLogger<HomeController>();

            var controller = new HomeController(mockRepo.Object, microsoftLogger);

            // Act
            var result = await controller.Index();

            InMemorySink.Instance
                .Should().HaveMessage("HomeController/Index").WithLevel(LogEventLevel.Information);
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());

            var microsoftLogger = new SerilogLoggerFactory(Log.Logger)
                .CreateLogger<HomeController>();

            var controller = new HomeController(mockRepo.Object, microsoftLogger);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new HomeController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            InMemorySink.Instance
                .Should().HaveMessage("Model is not valid.").WithLevel(LogEventLevel.Warning);
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange & Act
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var microsoftLogger = new SerilogLoggerFactory(Log.Logger)
                .CreateLogger<IdeasController>();
            var controller = new IdeasController(mockRepo.Object, microsoftLogger);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = await controller.CreateActionResult(model: null);

            // Assert
            InMemorySink.Instance
                .Should().HaveMessage("Model is not valid.").WithLevel(LogEventLevel.Error);
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            var microsoftLogger = new SerilogLoggerFactory(Log.Logger)
                .CreateLogger<SessionController>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object, microsoftLogger);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            InMemorySink.Instance
                .Should().HaveMessage("SessionController/Index").WithLevel(LogEventLevel.Debug);
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }
    }
}

