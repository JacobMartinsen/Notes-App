using NotesApp.NoteModel;
using NotesApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

List<NoteItem> notesStore = new List<NoteItem> ();
notesStore.Add(new NoteItem {Id = Guid.NewGuid(), Name = "TestNote1"});

// map controllers 
app.MapGet("/api/{id}", async (context) => NotesController.GetNote(notesStore, context.Request));
app.MapGet("/api/ListAll", () => NotesController.ListNotes(notesStore));
//app.MapPut("/api", () => NotesController.ListNotes(notesStore));
//app.MapDelete("/api", () => NotesController.ListNotes(notesStore));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.Run();