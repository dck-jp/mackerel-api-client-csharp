# Mackerel API Client for C#

## About

Mackerel API をC#から叩くためのライブラリ。[Mackerel API Client for Python](https://github.com/cm-watanabeseigo/mackerel-api-client-python)と同様の使い方。

Mackerel APIについては https://mackerel.io/ja/api-docs/ を参照のこと

## How to Use


```cs
using WebAPI;

var apiKey = "<YOUR API KEY>";
var m = new Makapi(apiKey);

m.get("org")
m.put("hosts/<hostId>")
m.post("hosts/<hostId>/status","{\"status\":\"standby\"}")
m.delete("services/<serviceName>")
```