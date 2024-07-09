FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY src/Project4.Domain/Project4.Domain.csproj ./src/Project4.Domain/
COPY src/Project4.Application/Project4.Application.csproj ./src/Project4.Application/
COPY src/Project4.Infrastructure/Project4.Infrastructure.csproj ./src/Project4.Infrastructure/
COPY src/Project4.Api/Project4.Api.csproj ./src/Project4.Api/
RUN dotnet restore ./src/Project4.Api/Project4.Api.csproj

COPY . ./
RUN dotnet publish ./src/Project4.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5432
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Project4.Api.dll"]
