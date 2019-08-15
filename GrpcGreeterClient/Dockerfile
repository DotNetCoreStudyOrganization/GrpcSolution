FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
ENV TZ=Asia/Shanghai
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
RUN sed -i "s@http://deb.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
&& sed -i "s@http://security.debian.org@http://mirrors.huaweicloud.com@g" /etc/apt/sources.list \
&& apt-get update && apt-get install -y --no-install-recommends libgdiplus libc6-dev
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["GrpcGreeterClient/GrpcGreeterClient.csproj", "GrpcGreeterClient/"]
RUN dotnet restore "GrpcGreeterClient/GrpcGreeterClient.csproj"
COPY . .
WORKDIR "/src/GrpcGreeterClient"
RUN dotnet build "GrpcGreeterClient.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GrpcGreeterClient.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GrpcGreeterClient.dll"]