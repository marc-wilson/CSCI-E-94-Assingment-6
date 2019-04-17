FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["HW6MovieSharing/HW6MovieSharing.csproj", "HW6MovieSharing/"]
RUN dotnet restore "HW6MovieSharing/HW6MovieSharing.csproj"
COPY . .
WORKDIR "/src/HW6MovieSharing"
RUN dotnet build "HW6MovieSharing.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HW6MovieSharing.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HW6MovieSharing.dll"]