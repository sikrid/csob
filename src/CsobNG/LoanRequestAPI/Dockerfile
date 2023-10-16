#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LoanRequestAPI/LoanRequestAPI.csproj", "LoanRequestAPI/"]
COPY ["Model/Model.csproj", "Model/"]
RUN dotnet restore "LoanRequestAPI/LoanRequestAPI.csproj"
COPY . .
WORKDIR "/src/LoanRequestAPI"
RUN dotnet build "LoanRequestAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanRequestAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanRequestAPI.dll"]