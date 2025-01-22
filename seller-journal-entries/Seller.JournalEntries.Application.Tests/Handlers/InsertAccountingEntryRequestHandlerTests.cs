using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Seller.JournalEntries.Application.AccountingEntries.InsertAccountingEntry;
using Seller.JournalEntries.Domain.Entities;
using Seller.JournalEntries.Domain.Interfaces.Repository;

namespace Seller.JournalEntries.Application.Tests.Handlers
{
    public class InsertAccountingEntryRequestHandlerTests
    {
        private readonly IAccountingEntryRepository _repository;
        private readonly IValidator<InsertAccountingEntryRequest> _validator;

        private readonly InsertAccountingEntryRequestHandler _class;
        private InsertAccountingEntryRequest _validRequest;
        private InsertAccountingEntryRequest _invalidRequest;

        public InsertAccountingEntryRequestHandlerTests()
        {
            _repository = Substitute.For<IAccountingEntryRepository>();
            _validator = new InsertAccountingEntryRequestValidator();
            _class = new InsertAccountingEntryRequestHandler(_validator, _repository);
        }

        [Fact]
        public async void InsertAccountingEntry_WhereValidData_ShouldReturnSucess() 
        {
            //Arrange
            InsertAccountingEntryRequest validRequest = new("Compra de moveis", 120, Domain.Enums.EEntryType.Debit, DateTime.Now);

            //Act
            var result = await _class.Handle(validRequest, new CancellationToken());

            //Assert
            _ = await _repository.Received().CreateAsync(Arg.Any<AccountingEntry>());
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task InsertAccountingEntry_WhereInvalidData_ShouldReturnError() 
        {
            //Arrange
            InsertAccountingEntryRequest invalidRequest = new("Compra de tintas", 0, Domain.Enums.EEntryType.Debit, DateTime.Now.AddDays(1));

            //Act
            var result = await _class.Handle(invalidRequest, new CancellationToken());

            //Assert
            _ = await _repository.Received(0).CreateAsync(Arg.Any<AccountingEntry>());
            result.IsSuccess.Should().BeFalse();
        }
    }
}
