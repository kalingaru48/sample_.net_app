#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["GearsMonoRepoSample.Manfucaturing.Web.Api/GearsMonoRepoSample.Manfucaturing.Web.Api.csproj", "GearsMonoRepoSample.Manfucaturing.Web.Api/"]
# RUN dotnet restore "GearsMonoRepoSample.Manfucaturing.Web.Api/GearsMonoRepoSample.Manfucaturing.Web.Api.csproj"
# COPY . .
# WORKDIR "/src/GearsMonoRepoSample.Manfucaturing.Web.Api"
# RUN dotnet build "GearsMonoRepoSample.Manfucaturing.Web.Api.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "GearsMonoRepoSample.Manfucaturing.Web.Api.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "GearsMonoRepoSample.Manfucaturing.Web.Api.dll"]