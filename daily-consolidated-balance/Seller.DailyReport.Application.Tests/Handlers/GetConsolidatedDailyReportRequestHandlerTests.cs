using FluentAssertions;
using NSubstitute;
using Seller.DailyReport.Application.DailyReports.GetConsolidatedDailyReport;
using Seller.DailyReport.Domain.Interfaces.Repository;

namespace Seller.DailyReport.Application.Tests.Handlers
{
    public class GetConsolidatedDailyReportRequestHandlerTests
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly GetConsolidatedDailyReportRequestHandler _class;

        public GetConsolidatedDailyReportRequestHandlerTests()
        {
            _repository = Substitute.For<IAccountingEntryRepository>();
            _class = new GetConsolidatedDailyReportRequestHandler(_repository);
        }

        [Fact]
        public async void GetConsolidatedDailyReport_Should_ReturnSucess() 
        {
            //Arrange
            GetConsolidatedDailyReportRequest request = new();

            //Act
            var result = await _class.Handle(request, new CancellationToken());

            //Assert
            _ = await _repository.Received().GetAllOfTodayAsync();
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async void GetConsolidatedDailyReport_WhenRepositoryFails_Should_ReturnFail()
        {
            //Arrange
            GetConsolidatedDailyReportRequest request = new();

            //Act
            var result = await _class.Handle(request, new CancellationToken());

            //Assert
            _ = await _repository.Received().GetAllOfTodayAsync();
            result.IsSuccess.Should().BeFalse();
        }
    }
}
