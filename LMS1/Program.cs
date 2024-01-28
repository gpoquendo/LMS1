using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/books/{status}", async context =>
    {
        var status = context.Request.RouteValues["status"];
        await context.Response.WriteAsync($"{status} Books:");
    });

    endpoints.MapGet("/books/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"Book id: {id}\n");
        await context.Response.WriteAsync($"Book title: Example Book\n");
        await context.Response.WriteAsync("Status: Available");
    });

    endpoints.MapPost("/books", async context =>
    {
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        dynamic bookData = JsonConvert.DeserializeObject(requestBody);
        await context.Response.WriteAsync($"New Book added: {requestBody}");
    });

    endpoints.MapPut("/books/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        await context.Response.WriteAsync($"Book with id {id} updated: {requestBody}");
    });

    endpoints.MapDelete("/books/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"Book with id {id} deleted successfully");
    });

    endpoints.MapGet("/borrowings", async context =>
    {
        await context.Response.WriteAsync("All Borrowings from readers:");
    });

    endpoints.MapGet("/borrowings/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        var borrowDate = "2021-10-10";
        var bookDetails = "Example Book";
        var readerInformation = "Example Reader";
        await context.Response.WriteAsync($"Borrowing id: {id}\nBorrow Date: {borrowDate}\nBook Details: {bookDetails}" +
            $"\nReader Information: {readerInformation}");
    });

    endpoints.MapPost("/borrowings", async context =>
    {
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        dynamic borrowingData = JsonConvert.DeserializeObject(requestBody);
        var borrowingId = borrowingData.id;
        var bookDetails = borrowingData.bookDetails;
        var readerInformation = borrowingData.readerInformation;
        var borrowDate = borrowingData.borrowDate;
        await context.Response.WriteAsync($"New Borrowing created:\nBorrowing id: {borrowingId}\nBorrow Date: {borrowDate}" +
            $"\nBook Details: {bookDetails}\nReader Information: {readerInformation}");
    });

    endpoints.MapPut("/borrowings/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        dynamic borrowingData = JsonConvert.DeserializeObject(requestBody);
        var bookDetails = borrowingData.bookDetails;
        var readerInformation = borrowingData.readerInformation;
        var borrowDate = borrowingData.borrowDate;
        await context.Response.WriteAsync($"Borrowing with id {id} updated:\nBorrow Date: {borrowDate}\nBook Details: {bookDetails}" +
            $"\nReader Information: {readerInformation}");
    });

    endpoints.MapDelete("/borrowings/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"Borrowing with id {id} cancelled successfully");
    });

    endpoints.MapGet("/readers", async context =>
    {
        await context.Response.WriteAsync("All Readers:");
    });

    endpoints.MapGet("/readers/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        var readerName = "Peter Oquendo";
        var readerAddress = "Calgary";
        var readerPhone = "444-123-4567";
        await context.Response.WriteAsync($"Reader id: {id}\nName: {readerName}\nAddress: {readerAddress}\nPhone: {readerPhone}");
    });

    endpoints.MapPost("/readers", async context =>
    {
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        dynamic readerData = JsonConvert.DeserializeObject(requestBody);
        var readerId = readerData.id;
        var readerName = readerData.name;
        var readerAddress = readerData.address;
        var readerPhone = readerData.phone;
        await context.Response.WriteAsync($"New Reader created:\nReader id: {readerId}" +
                       $"\nName: {readerName}\nAddress: {readerAddress}\nPhone: {readerPhone}");
    });

    endpoints.MapPut("/readers/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        dynamic readerData = JsonConvert.DeserializeObject(requestBody);
        var readerName = readerData.name;
        var readerAddress = readerData.address;
        var readerPhone = readerData.phone;
        await context.Response.WriteAsync($"Reader with id {id} updated:\nReader Name: {readerName}" +
                       $"\nReader Address: {readerAddress}\nReader Phone: {readerPhone}");
    });

    endpoints.MapDelete("/readers/{id:int}", async context =>
    {
        var id = context.Request.RouteValues["id"];
        await context.Response.WriteAsync($"Reader with id {id} deleted successfully");
    });
});

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("This is default page!");
});

app.Run();
