#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["GearsMonoRepoSample.Finance.Web.Api/GearsMonoRepoSample.Finance.Web.Api.csproj", "GearsMonoRepoSample.Finance.Web.Api/"]
# RUN dotnet restore "GearsMonoRepoSample.Finance.Web.Api/GearsMonoRepoSample.Finance.Web.Api.csproj"
# COPY . .
# WORKDIR "/src/GearsMonoRepoSample.Finance.Web.Api"
# RUN dotnet build "GearsMonoRepoSample.Finance.Web.Api.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "GearsMonoRepoSample.Finance.Web.Api.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "GearsMonoRepoSample.Finance.Web.Api.dll"]