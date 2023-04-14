﻿using StackExchange.Redis;

namespace MicroServices.Services.Basket.Services
{
    public class RedisService
    {
        private readonly string _host;
        private readonly string _port;

        private ConnectionMultiplexer connectionMultiplexer;

        public RedisService(string host, string port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => connectionMultiplexer.GetDatabase(db);
    }
}
