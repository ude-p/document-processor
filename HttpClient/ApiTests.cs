using System;

namespace HttpClient;

public class ApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly System.Net.Http.HttpClient _client;

    public ApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task GetEndpoint_ShouldReturn200()
    {
        var response = await _client.GetAsync("/");

        Console.WriteLine(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UploadJson_ShouldReturnSameContent()
    {
        string jsonContent = "{\"name\": \"John Doe\", \"age\": 30}";
        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/api/upload", content);

        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"Response: {response.StatusCode}, Body: {responseBody}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("John Doe", responseBody);
        Assert.Contains("30", responseBody);
    }

    [Fact]
    public async Task UploadXml_ShouldReturnSameContent()
    {
        string xmlContent = "<person><name>Jane Doe</name><age>25</age></person>";
        var content = new StringContent(xmlContent, Encoding.UTF8, "application/xml");

        var response = await _client.PostAsync("/api/upload", content);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var responseString = await response.Content.ReadAsStringAsync();

        Assert.Contains("Jane Doe", responseString);
        Assert.Contains("25", responseString);
    }
}