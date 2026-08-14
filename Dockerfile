FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ToDoList.csproj ./
RUN dotnet restore ToDoList.csproj

COPY . .
RUN dotnet publish ToDoList.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_ENVIRONMENT=Production
EXPOSE 10000

# O Render injeta a porta em $PORT; o fallback cobre execucao local.
ENTRYPOINT ["sh", "-c", "dotnet ToDoList.dll --urls http://0.0.0.0:${PORT:-10000}"]
