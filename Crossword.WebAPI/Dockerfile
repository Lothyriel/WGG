#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Crossword.WebAPI/Crossword.WebAPI.csproj", "Crossword.WebAPI/"]
COPY ["Crossword.Application/Crossword.Application.csproj", "Crossword.Application/"]
COPY ["Crossword.Domain/Crossword.Domain.csproj", "Crossword.Domain/"]
COPY ["Term.Domain/Term.Domain.csproj", "Term.Domain/"]
RUN dotnet restore "Crossword.WebAPI/Crossword.WebAPI.csproj"
COPY . .
WORKDIR "/src/Crossword.WebAPI"
RUN dotnet build "Crossword.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Crossword.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Crossword.WebAPI.dll"]