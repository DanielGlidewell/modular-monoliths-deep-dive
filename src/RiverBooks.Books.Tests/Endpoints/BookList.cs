using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookList(Fixture fixture) : TestBase<Fixture> {
    [Fact]
    public async Task ReturnsThreeBooksAsync() {
      var testResult = await fixture.Client.GETAsync<List, ListBooksResponse>();

      testResult.Response.EnsureSuccessStatusCode();
      testResult.Result.Books.Count.Should().Be(3);
    }
}

public class BookGetById(Fixture fixture) : TestBase<Fixture> {
  [Theory]
  [InlineData("F4B3E3B2-3B9A-4B5D-9B7B-2B0D7B3DCB6D", "The Fellowship of the Ring")]
  [InlineData("F4B3E3B2-3B9A-4B5D-9B7B-2B0D7B3DCB6E", "The Two Towers")]
  [InlineData("F4B3E3B2-3B9A-4B5D-9B7B-2B0D7B3DCB6F", "The Return of the King")]
  public async Task ReturnsExpectedBookGivenIdAsync(string validId, string expectedTitle) {
    var id = Guid.Parse(validId);
    var testResult = await fixture.Client.GETAsync<GetById, GetBookByIdRequest, BookDto>(new() { Id = id });

    testResult.Response.EnsureSuccessStatusCode();
    testResult.Result.Title.Should().Be(expectedTitle);
  }
}