 var 
        gameport        = 3000,
        io              = require('socket.io'),
        UUID            = require('node-uuid'),
        verbose         = false,
        app             = require('express')();
		server 			= require('http').Server(app);


    server.listen( gameport );
    console.log('\t :: Express :: Listening on port ' + gameport );

    var sio = io.listen(server);

    sio.sockets.on('connection', function (client) {
        
        client.userid = UUID();
        client.emit('onconnected', { id: client.userid, ids : "hello"} );
        console.log('\t socket.io:: player ' + client.userid + ' connected');
        client.on('disconnect', function () {
            console.log('\t socket.io:: client disconnected ' + client.userid );

        });
     
    });
	

/*var io = require('socket.io')({
	transports: ['websocket'],
});

io.attach(4004);

io.on('connection', 
	function(socket)
	{
		socket.on('beep', 
			function()
			{
				socket.emit('boop');
			});
	})
*/