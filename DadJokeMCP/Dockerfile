FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["DadJokeMCP/DadJokeMCP.csproj", "DadJokeMCP/"]
COPY ["DadJokeMCP.Shared/DadJokeMCP.Shared.csproj", "DadJokeMCP.Shared/"]
RUN dotnet restore "DadJokeMCP/DadJokeMCP.csproj"

COPY . .
WORKDIR "/src/DadJokeMCP"
RUN dotnet publish "DadJokeMCP.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/runtime:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "DadJokeMCP.dll"]