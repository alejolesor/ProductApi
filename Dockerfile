FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS builder
WORKDIR /app1

COPY ./ ./

WORKDIR /app1/ProductManagement.Api/

RUN dotnet restore


RUN dotnet publish -c Release -o ./../build

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app1
COPY --from=builder /app1/build/ ./
ENTRYPOINT ["dotnet", "ProductManagement.Api.dll"]
