#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Dictionary.WebAPI/Term.WebAPI.csproj", "Dictionary.WebAPI/"]
COPY ["Game.Application/Crossword.Application.csproj", "Game.Application/"]
COPY ["Game.Domain/Crossword.Domain.csproj", "Game.Domain/"]
RUN dotnet restore "Dictionary.WebAPI/Term.WebAPI.csproj"
COPY . .
WORKDIR "/src/Dictionary.WebAPI"
RUN dotnet build "Term.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Term.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Term.WebAPI.dll"]