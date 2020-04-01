const http = require("http");
const net = require("net");
const sql = require("mssql");
const fs = require('fs');


const ports = [21, 22, 23, 80, 209, 311, 443, 514, 1337, 1801, 2375, 2376, 3074, 3306, 5050, 6516, 8080, 8243, 563, 711, 80]

const knownPorts = {
    20: "FTP Data Transferer",
    21: "FTP Control Command",
    22: "SSH",
    23: "Telenet",
    80: "HTTP",
    209: "QMTP",
    311: "MacOS",
    443: "HTTPS",
    514: "RSH",
    1337: "neo4j-shell",
    1801: "MSMQ",
    2375: "Docker Plain",
    2376: "Docker Plain SSl",
    3074: "XBOX LIVE",
    3306: "MySql",
    5050: "Yahoo! Messenger",
    6516: "Windows Admin Center",
    8080: "HTTP",
    8243: "HTTP Apache Synapse",
    563: "NNTP",
    711: "Cisco"
}

const result = {};
let resStr = "";

// Declare port scan function
let portScan = (target) => {

    // Itterate trough ports
    for (var i = 0; i < ports.length; i++) {

        // Initialize socket for each port
        let customSocket = new net.Socket();

        // Connect to port
        customSocket.connect({
            host: target,
            port: ports[i]
        });

        // On connected to port
        customSocket.on("connect", () => {
            console.log("Open port: " + customSocket.remotePort + " " + knownPorts[customSocket.remotePort])
            console.log("Socket connected at: " + customSocket.remoteAddress)
            console.log(result);
            resStr += customSocket.remotePort + "|" + knownPorts[customSocket.remotePort];
            resStr += ";";
            return result[customSocket.remotePort] = knownPorts[customSocket.remotePort];
        })

        // Port closed
        customSocket.on("error", (err) => {
            //console.log("Closed port discoverd");
        })
    }
}



// Main server
let server = http.createServer((req, res) => {

    // Gets data from Blog
    const body = [];
    let parsedBody = "";
    // Target host
    let target = "";
    if (req.url === "/api/scan" && req.method == "POST") {
        // Read trough data and add to array
        req.on("data", (chunk) => {
            body.push(chunk);
        })
        // Parse data and call port scan
        req.on("end", () => {
            parsedBody = Buffer.concat(body).toString();
            console.log("DATA: " + parsedBody)
            target = parsedBody.split("=")[1];
            
            portScan(target);
           
        })

        setTimeout(() => {
            console.log(resStr);
            res.write(resStr);
            resStr = "";
            res.end();
        }, 600)
      
    }
    else {
        console.log("You need to post data not get.")
    }
});

server.listen(3000);   


console.log('Node server listening on port 3000');