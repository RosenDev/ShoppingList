FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingList/ShoppingList.csproj", "ShoppingList/"]
COPY ["../ShoppingList.Data.Domain/ShoppingList.Data.Domain.csproj", "ShoppingList.Data.Domain/"]

RUN dotnet restore "ShoppingList/ShoppingList.csproj"
COPY . .
WORKDIR "/src/ShoppingList"
RUN dotnet build "ShoppingList.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingList.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingList.dll"]