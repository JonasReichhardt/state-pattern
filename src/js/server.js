var express = require("express");
var http = require("http");
var app = express();
var server = http.createServer(app);
const port = 3000;

server.listen(port, function () {
    console.log('Server is listening on port %d', port);
})

app.use(express.static(__dirname+"/assets"));