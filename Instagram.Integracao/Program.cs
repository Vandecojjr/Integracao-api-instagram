using Instagram.Integracao.Handlers;
using Instagram.Integracao.Handlers.Contracts;
using Instagram.Integracao.Models;
using Instagram.Integracao.Models.Contracts;
using Instagram.Integracao.Services;
using Instagram.Integracao.Services.Contracts;
using Instagram.Integracao.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddTransient<IHandler<CriarpublicacaoDePost>, PostHandler>();
builder.Services.AddTransient<IHandler<CriarpublicacaoDeStory>, StoryHandler>();
builder.Services.AddTransient<IHandler<CriarBuscaDeMensagem>, BuscarMensagemHandler>();
builder.Services.AddTransient<IHandler<CriarpublicacaoDeMensagem>, CriarMensagemHandler>();
builder.Services.AddTransient<IHandler<CriarBuscaDeComentario>, ComentarioHandler>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IStoryService, StoryService>();
builder.Services.AddTransient<IComentarioService, ComentarioService>();
builder.Services.AddTransient<IMensagemService, MensagemService>();
builder.Services.AddTransient<IJsonService, JsonService>();
builder.Services.AddTransient<IRequisicaoPostService, RequisicaoPostService>();
builder.Services.AddTransient<IRequisicaoComentario, RequisicaoComentario>();
builder.Services.AddTransient<IRequisicaoStory, RequisicaoStory>();
builder.Services.AddTransient<IRequisicaoMensagem, RequisicaoMensagem>();
builder.Services.Configure<GraphApi>(builder.Configuration.GetSection("GraphApi"));
builder.Services.AddHttpClient("Instagram", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://graph.facebook.com/v20.0/");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
