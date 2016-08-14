#! /bin/bash

# Hack to set MongoDb server IP address to an env variable since the 
# MongoDB driver on .NET Core can't connect to a socket by host name. 
export MongoDbServer=$(ping -c 1 mongo | 
grep "64 bytes from" | 
awk '{print $4}' | 
sed 's/:$//')

dotnet run --server.urls http://0.0.0.0:5000